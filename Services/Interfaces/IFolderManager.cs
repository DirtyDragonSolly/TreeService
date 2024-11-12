using TreeService.Models.Entities;
using TreeService.Models.Requests.FolderModels;
using TreeService.Models.Responses.FolderModels;

namespace TreeService.Services.Interfaces
{
    public interface IFolderManager
    {
        Task<List<Folder>> GetAllFoldersAsync();
        Task<Folder> GetAsync(Guid id);
        Task<Guid> CreateAsync(CreateFolderRequest folderRequest);
        Task UpdateAsync(UpdateFolderRequest folderRequest);
        Task DeleteAsync(DeleteFolderRequest folderRequest);
    }
}
