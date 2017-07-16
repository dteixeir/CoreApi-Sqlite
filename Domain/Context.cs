using System.IO;
using Microsoft.EntityFrameworkCore;

namespace dotNetApi.Domain
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Beer> Beers { get; set; }
    public DbSet<Brewery> Breweries { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Style> Styles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Filename=./beer.db");
    }
  }
}