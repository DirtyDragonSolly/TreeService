namespace TreeServiceClient.Models.Responses.FolderModels
{
    public class GetFolderResponse
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}
