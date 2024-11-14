using AutoMapper;
using TreeService.Helpers;
using TreeService.Models.Entities;
using TreeService.Models.Requests.FolderModels;
using TreeService.Models.Responses.FolderModels;
using TreeService.Repositories.Interfaces;
using TreeService.Services.Interfaces;

namespace TreeService.Services.Implementations
{
    public class FolderManager : IFolderManager
    {
        private readonly IMapper _mapper;
        private readonly IFolderRepository _folderRepository;

        public FolderManager(
            IMapper mapper,
            IFolderRepository folderRepository)
        {
            _mapper = mapper;
            _folderRepository = folderRepository;
        }

        public async Task<List<GetFolderResponse>> GetAllAsync()
        {
            var folders = await _folderRepository.GetAllActiveAsync();

            var result = folders
                .Select(_mapper.Map<GetFolderResponse>)
                .ToList();

            return result;
        }

        public async Task<GetFolderResponse?> GetAsync(Guid id)
        {
            var folder = await _folderRepository.GetAsync(id);

            var result = _mapper.Map<GetFolderResponse>(folder);

            return result;
        }

        public async Task<GetFolderTreeResponse?> GetTreeAsync(Guid folderId)
        {
            var folders = await _folderRepository.GetTreeAsync(folderId);

            return FolderHelper.BuildFolderTree(folders, folderId);
        }

        public async Task<Guid> CreateAsync(CreateFolderRequest folderRequest)
        {
            var id = Guid.NewGuid();

            var folderEntity = new Folder
            {
                Id = id,
                Name = folderRequest.Name,
                ParentId = folderRequest.ParentId
            };

            var result = await _folderRepository.CreateAsync(folderEntity);

            return result;
        }

        public async Task UpdateAsync(UpdateFolderRequest folderRequest)
        {
            var folder = await _folderRepository.GetAsync(folderRequest.Id);
            if (folder == null)
            {
                throw new Exception("folder not found");
            }

            if (folder.Name == folderRequest.Name 
                && folder.ParentId == folderRequest.ParentId)
            {
                return;
            }

            folder.Name = folderRequest.Name;
            folder.ParentId = folderRequest.ParentId;

            await _folderRepository.UpdateAsync(folder);
        }

        public async Task DeleteAsync(DeleteFolderRequest folderRequest)
        {
            await _folderRepository.DeleteAsync(folderRequest.Id);
        }
    }
}
