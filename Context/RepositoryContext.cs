using Microsoft.EntityFrameworkCore;
using Rss_Reader_BackEnd.Models;

namespace Rss_Reader_BackEnd.Context;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) {}

    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }

}