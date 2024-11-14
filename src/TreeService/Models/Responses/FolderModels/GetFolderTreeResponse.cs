namespace TreeService.Models.Responses.FolderModels
{
    public class GetFolderTreeResponse
    {
        public Guid Id { get; set; }

        public required string Name {  get; set; }

        public IEnumerable<GetFolderTreeResponse>? Children { get; set; }
    }
}
