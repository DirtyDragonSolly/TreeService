using Microsoft.EntityFrameworkCore;
using TreeService.Data;
using TreeService.Models.Entities;
using TreeService.Models.Requests.FolderModels;
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
            var folder = await _context.Folders.FirstAsync(f => f.Id == id);

            return folder;
        }

        public async Task<Guid> CreateAsync(CreateFolderRequest folderRequest)
        {
            //Creating folder and save it in DB
            var id = Guid.NewGuid();
            _context.Folders.Add(new Folder
            {
                Id = id,
                Name = folderRequest.Name,
                ParentId = folderRequest.ParentId
            });
            await _context.SaveChangesAsync();

            //Code 200 with parent
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

        private async Task<Folder> MapCategory(Folder folder)
        {
            folder.Children = await Task.WhenAll(folder.Children.Select(fc => MapCategory(fc)));

            return folder;
        }
    }
}
