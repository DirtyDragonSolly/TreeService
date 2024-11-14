namespace TreeService.Models.Entities
{
    public class Folder
    {
        public Guid Id { get; set; }

        public string Name { get; set; }        

        public Guid? ParentId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
