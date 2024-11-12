using TreeService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TreeService.Data
{
    public class FoldersContext : DbContext
    {
        public FoldersContext(DbContextOptions<FoldersContext> options) : base(options)
        { 
        }

        public DbSet<Folder> Folders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>().ToTable("Folders");
            modelBuilder.Entity<Folder>()
                .HasMany(f => f.Children)
                .WithMany()
                .HasForeignKey(f => f.ParentFolderId);
        }
    }
}
