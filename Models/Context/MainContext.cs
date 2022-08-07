using Microsoft.EntityFrameworkCore;

public class MainContext : DbContext
{
    public DbSet<Team> Team { get; set; }
    public DbSet<Player> Player { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Team>(entity =>
      {
        entity.HasKey(e => e.TeamId);
        entity.Property(e => e.Name).IsRequired();
        entity.Property(e => e.Manager).IsRequired();
      });

      modelBuilder.Entity<Player>(entity =>
      {
        entity.HasKey(e => e.PlayerId);
        entity.Property(e => e.Name).IsRequired();
        entity.Property(e => e.Age).IsRequired();
        entity.HasOne(d => d.Team)
          .WithMany(p => p.Players);
      });
    }

}