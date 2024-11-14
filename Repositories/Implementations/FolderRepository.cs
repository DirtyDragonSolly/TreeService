using Microsoft.EntityFrameworkCore;
using TreeService.Data;
using TreeService.Models.Entities;
using TreeService.Repositories.Interfaces;

namespace TreeService.Repositories.Implementations
{
    public class FolderRepository : IFolderRepository
    {
        private readonly FoldersContext _context;

        public FolderRepository(FoldersContext context)
        {
            _context = context;
        }

        public async Task<List<Folder>> GetAllActiveAsync()
        {
            var folders = await _context.Folders.Where(w => w.IsActive).ToListAsync();

            return folders;
        }

        public async Task<Folder?> GetAsync(Guid id)
        {
            var folder = await _context.Folders.FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

            return folder;
        }

        public async Task<List<Folder>> GetTreeAsync(Guid folderId)
        {
            var folders = await _context.Folders
                .FromSqlRaw(@"
                    WITH RECURSIVE FolderTree AS (
                        SELECT * FROM folders WHERE ""Id"" = {0}
                            AND ""IsActive"" = true

                        UNION ALL

                        SELECT 
                            f.* 
                        FROM folders f
                        INNER JOIN FolderTree ft ON f.""ParentId"" = ft.""Id""
                        WHERE f.""IsActive"" = true
                    )
                    SELECT * FROM FolderTree", folderId)
                .ToListAsync();

            return folders;
        }

        public async Task<Guid> CreateAsync(Folder folderEntity)
        {
            _context.Folders.Add(folderEntity);

            await _context.SaveChangesAsync();

            return folderEntity.Id;
        }

        public async Task UpdateAsync(Folder folder)
        {
            _context.Update(folder);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Database.ExecuteSqlRawAsync(@"
                WITH RECURSIVE FolderTree AS (
                    SELECT * FROM folders WHERE ""Id"" = {0}
                        AND ""IsActive"" = true

                    UNION ALL

                    SELECT 
                        f.* 
                    FROM folders f
                    INNER JOIN FolderTree ft ON f.""ParentId"" = ft.""Id""
                    WHERE f.""IsActive"" = true
                )
                UPDATE folders
                SET ""IsActive"" = false
                WHERE ""Id"" IN (SELECT ""Id"" FROM FolderTree);", id);
        }
    }
}
