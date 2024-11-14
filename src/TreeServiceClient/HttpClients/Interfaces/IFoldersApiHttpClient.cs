using TreeServiceClient.Models.Requests.FolderModels;
using TreeServiceClient.Models.Responses.FolderModels;

namespace TreeServiceClient.HttpClients.Interfaces
{
    public interface IFoldersApiHttpClient
    {
        Task<List<GetFolderResponse>> GetAllAsync();
        Task<GetFolderResponse?> GetAsync(Guid id);
        Task<GetFolderTreeResponse> GetTreeAsync(Guid id);
        Task<HttpResponseMessage> CreateAsync(CreateFolderRequest request);
        Task<HttpResponseMessage> EditAsync(UpdateFolderRequest request);
        Task<HttpResponseMessage> DeleteAsync(DeleteFolderRequest request);
    }
}
