using TreeService.Models.Entities;

namespace TreeService.Models.Responses.FolderModels
{
    public class GetFolderResponse
    {
        public Guid Id { get; set; }

        public required string Nmae {  get; set; }

        public IEnumerable<Folder> Children { get; set; }
    }
}
