namespace TreeService.Models.Entities
{
    public class Folder
    {
        public Guid Id { get; set; }

        public string Name { get; set; }        

        public bool IsActive { get; set; } = true;

        public Guid? ParentId { get; set; }

        public Folder? Parent { get; set; }

        public IEnumerable<Folder>? Children { get; set; }
    }
}
