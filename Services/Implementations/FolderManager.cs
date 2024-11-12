using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using TreeService.Data;
using TreeService.Models.Entities;
using TreeService.Models.Requests.FolderModels;
using TreeService.Models.Responses.FolderModels;
using TreeService.Services.Interfaces;

namespace TreeService.Services.Implementations
{
    public class FolderManager : IFolderManager
    {
        private readonly FoldersContext _context;

        public FolderManager(FoldersContext context)
        {
            _context = context;
        }

        public async Task<List<Folder>> GetAllFoldersAsync()
        {
            return await _context.Folders.ToListAsync();
        }

        public async Task<Folder> GetAsync(Guid id)
        {
            return await _context.Folders
                .Include(e => e.Children)
                .FirstAsync(e => e.Id == id);
        }

        public async Task<Guid> CreateAsync(CreateFolderRequest folderRequest)
        {
            var id = Guid.NewGuid();
            _context.Folders.Add(new Folder
            {
                Id = id,
                Name = folderRequest.Name,
                ParentFolderId = folderRequest.ParentFolderId,
            });
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task UpdateAsync(UpdateFolderRequest folderRequest)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(DeleteFolderRequest folderRequest)
        {
            throw new NotImplementedException();
        }
    }
}
