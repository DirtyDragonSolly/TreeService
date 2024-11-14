using System.ComponentModel.DataAnnotations;

namespace TreeServiceClient.Models.Requests.FolderModels
{
    public class UpdateFolderRequest
    {
        public Guid Id { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        public required string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}
