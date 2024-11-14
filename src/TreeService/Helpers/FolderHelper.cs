using TreeService.Models.Entities;
using TreeService.Models.Responses.FolderModels;

namespace TreeService.Helpers
{
    public static class FolderHelper
    {
        public static GetFolderTreeResponse? BuildFolderTree(List<Folder> folders, Guid rootFolderId)
        {
            var rootFolder = folders.FirstOrDefault(f => f.Id == rootFolderId);

            if (rootFolder == null)
            {
                return null;
            }

            var result = new GetFolderTreeResponse
            {
                Id = rootFolder.Id,
                Name = rootFolder.Name,
                Children = GetFolderChildren(rootFolder.Id, folders)
            };

            return result;
        }

        private static IEnumerable<GetFolderTreeResponse>? GetFolderChildren(Guid folderId, IEnumerable<Folder> folders)
        {
            if (!folders.Any(x => x.ParentId.HasValue && x.ParentId.Value == folderId))
            {
                return null;
            }

            return folders
                .Where(w => w.ParentId.HasValue && w.ParentId.Value == folderId)
                .Select(s =>
                {
                    return new GetFolderTreeResponse
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Children = GetFolderChildren(s.Id, folders)
                    };
                });
        }
    }
}
