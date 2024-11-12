using System.ComponentModel.DataAnnotations;

namespace TreeService.Models.Requests.FolderModels
{
    public class DeleteFolderRequest
    {
        [Required]
        Guid Id { get; set; }
    }
}
