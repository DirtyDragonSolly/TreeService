using TreeService.Models.Entities;
using TreeService.Models.Requests.FolderModels;
using TreeService.Models.Responses.FolderModels;

namespace TreeService.Services.Interfaces
{
    public interface IFolderManager
    {
        Task<List<GetFolderResponse>> GetAllAsync();
        Task<GetFolderResponse?> GetAsync(Guid id);
        Task<GetFolderTreeResponse?> GetTreeAsync(Guid folderId);
        Task<Guid> CreateAsync(CreateFolderRequest folderRequest);
        Task UpdateAsync(UpdateFolderRequest folderRequest);
        Task DeleteAsync(DeleteFolderRequest folderRequest);
    }
}
