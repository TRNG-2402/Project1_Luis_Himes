using Microsoft.EntityFrameworkCore;
using BookCatalog.Models;
using Microsoft.Extensions.Logging;



namespace BookCatalog.Data;

public class AppDbContext : DbContext
{
    public AppDbContext() : base() { }

    public AppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Genre> Genres { get; set; }

    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(c => c.GenreId);

            entity.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(c => c.AuthorId);

            entity.Property(c => c.Name);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.CustomerId);

            entity.Property(c => c.First_Name)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(c => c.Last_Name)
            .IsRequired()
            .HasMaxLength(100);
        });


        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(c => c.OrderId);

            entity.Property(c => c.DateOrdered);

            entity
               .HasOne(p => p.Customer)
               .WithMany(c => c.Orders)
               .HasForeignKey(p => p.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(c => c.BookId);

            entity.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

            entity
               .HasOne(p => p.Genre)
               .WithMany(c => c.Books)
               .HasForeignKey(p => p.GenreId)
               .OnDelete(DeleteBehavior.Restrict);

            entity
               .HasOne(p => p.Author)
               .WithMany(c => c.Books)
               .HasForeignKey(p => p.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasMany(p => p.Orders)
                .WithMany(c => c.Books)
                .UsingEntity(
                    l => l.HasOne(typeof(Order)).WithMany().HasConstraintName("OrderForeignKey_Constraint"),
                    r => r.HasOne(typeof(Book)).WithMany().HasConstraintName("BookForeignKey_Constraint")
                );

        });








    }
}
