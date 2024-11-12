using System.ComponentModel.DataAnnotations;

namespace TreeService.Models.Requests.FolderModels
{
    public class UpdateFolderRequest
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
