using System.ComponentModel.DataAnnotations;
using TreeService.Models.Entities;

namespace TreeService.Models.Requests.FolderModels
{
    public class CreateFolderRequest
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}
