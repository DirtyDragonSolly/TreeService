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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>().ToTable("Folders");
            modelBuilder.Entity<Folder>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId);
        }
    }
}
