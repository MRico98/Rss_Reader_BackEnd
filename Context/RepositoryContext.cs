using Microsoft.EntityFrameworkCore;
using Rss_Reader_BackEnd.Models;

namespace Rss_Reader_BackEnd.Context;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) {}

    public DbSet<Item>? Items { get; set; }
    public DbSet<CategoryItem>? Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasDefaultSchema("RssReader");
        modelBuilder.Entity<Item>().ToTable("Item");
        modelBuilder.Entity<Item>().HasKey(b => b.Id).HasName("PrimaryKey_ItemId");
        modelBuilder.Entity<Item>().Property(s => s.Title).HasColumnName("Title").IsRequired();
        modelBuilder.Entity<Item>().Property(s => s.Description).HasColumnName("Description").IsRequired();
        modelBuilder.Entity<Item>().Property(s => s.CreationDate).HasColumnName("CreationDate").IsRequired();
        modelBuilder.Entity<Item>().Property(s => s.Url).HasColumnName("Url").IsRequired();

        modelBuilder.Entity<CategoryItem>().ToTable("CategoryItem");
        modelBuilder.Entity<CategoryItem>().HasKey(b => new { b.CategoryName, b.ItemForeignKey }).HasName("Name");
        modelBuilder.Entity<CategoryItem>().HasOne(b => b.Item).WithMany(b => b.CategoryItems).HasForeignKey(b => b.ItemForeignKey);
    }

}