using Microsoft.EntityFrameworkCore;
using Domain.Variant_Full;

namespace Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<PublisherAuthor> PublishersAuthors { get; set; }

    public AppDbContext(DbContextOptions opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>(b =>
        {
            b.ToTable("Publisher");
            b.HasKey(x => x.Id).HasName("PK_Publishers_Id");
        });

        modelBuilder.Entity<Author>(b =>
        {
            b.ToTable("Author");
            b.HasKey(x => x.Id).HasName("PK_Authors_Id");
        });

        modelBuilder.Entity<Publisher>()
            .HasMany(publisher => publisher.Authors)
            .WithMany(author => author.Publishers)
            .UsingEntity<PublisherAuthor>( // PublisherAuthor -> pa
                b => b
                    .HasOne(pa => pa.Author)
                    .WithMany(author => author.PublishersAuthors)
                    .HasForeignKey(pa => pa.AuthorId)
                    .HasConstraintName("FK_PublishersAuthors_AuthorId")
                    .OnDelete(DeleteBehavior.Cascade),
                b => b
                    .HasOne(pa => pa.Publisher)
                    .WithMany(publisher => publisher.PublishersAuthors)
                    .HasForeignKey(pa => pa.PublisherId)
                    .HasConstraintName("FK_PublishersAuthors_PublisherId")
                    .OnDelete(DeleteBehavior.Cascade),
                b =>
                {
                    b.ToTable("PublishersAuthors");
                    b.HasKey(pa => new { pa.PublisherId, pa.AuthorId }).HasName("PK_PublishersAuthors_PublisherId_AuthorId");
                    b.HasIndex(pa => pa.PublisherId, "IX_PublishersAuthors_PublisherId").IsUnique(false);
                    b.HasIndex(pa => pa.AuthorId, "IX_PublishersAuthors_AuthorId").IsUnique(false);
                }
            );
    }
}