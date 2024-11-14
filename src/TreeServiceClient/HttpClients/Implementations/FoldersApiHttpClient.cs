using TreeServiceClient.HttpClients.Interfaces;
using TreeServiceClient.Models.Requests.FolderModels;
using TreeServiceClient.Models.Responses.FolderModels;

namespace TreeServiceClient.HttpClients.Implementations
{
    public class FoldersApiHttpClient : IFoldersApiHttpClient
    {
        private readonly HttpClient _httpClient;

        public FoldersApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetFolderResponse>> GetAllAsync()
        {
            var folders = await _httpClient.GetFromJsonAsync<List<GetFolderResponse>>("");

            return folders;
        }

        public async Task<GetFolderResponse?> GetAsync(Guid id)
        {
            var folder = await _httpClient.GetFromJsonAsync<GetFolderResponse>($"{id}");

            return folder;
        }

        public async Task<GetFolderTreeResponse> GetTreeAsync(Guid id)
        {
            var folderTree = await _httpClient.GetFromJsonAsync<GetFolderTreeResponse>($"tree?id={id}");

            return folderTree;
        }

        public async Task<HttpResponseMessage> CreateAsync(CreateFolderRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("", request);

            return response;
        }

        public async Task<HttpResponseMessage> EditAsync(UpdateFolderRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync("", request);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(DeleteFolderRequest request)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, "")
            {
                Content = JsonContent.Create(request)
            });

            return response;
        }
    }
}
