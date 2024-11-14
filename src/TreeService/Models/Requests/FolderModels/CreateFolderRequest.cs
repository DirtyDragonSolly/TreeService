using System.ComponentModel.DataAnnotations;

namespace TreeService.Models.Requests.FolderModels
{
    public class CreateFolderRequest
    {
        [MinLength(1)]
        [MaxLength(100)]
        public required string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}
