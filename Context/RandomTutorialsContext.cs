using Microsoft.EntityFrameworkCore;

using RandomTutorialsAPI.Models;

namespace RandomTutorialsAPI.Context;

public class RandomTutorialsContext(DbContextOptions<RandomTutorialsContext> options) : DbContext(options)
{
    public DbSet<Tutorial> Tutorials { get; set; } = default!;

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<Tag> Tags { get; set; } = default!;

    public DbSet<TagTutorialMapping> TagTutorialMapping { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable( "SUPABASE_CONNECTION_STRING" ) );
        }
    }

}