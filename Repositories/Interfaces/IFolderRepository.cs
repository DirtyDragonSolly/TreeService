using TreeService.Models.Entities;

namespace TreeService.Repositories.Interfaces
{
    public interface IFolderRepository
    {
        Task<List<Folder>> GetAllActiveAsync();
        Task<Folder?> GetAsync(Guid id);
        Task<List<Folder>> GetTreeAsync(Guid folderId);
        Task<Guid> CreateAsync(Folder folder);
        Task UpdateAsync(Folder folder);
        Task DeleteAsync(Guid id);
    }
}
