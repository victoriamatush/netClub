using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace SoftServeProject
{
    public partial class UserDBContext : DbContext
    {
        public UserDBContext()
        {
            Database.EnsureCreated();
        }

        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public  DbSet<Author> Authors { get; set; }
        public  DbSet<Book> Books { get; set; }
        public  DbSet<Reader> Readers { get; set; }
        public  DbSet<Request> Requests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("AUTHOR");

                entity.Property(e => e.Authorid).HasColumnName("AUTHORID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SURNAME");

            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOK");

                entity.Property(e => e.Bookid)
                .HasColumnName("BOOKID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.ToTable("READER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.IsManager).HasColumnName("IS_MANAGER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("REQUEST");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BOOK_ID");

                entity.Property(e => e.DateOfRequest)
                    .HasColumnType("date")
                    .HasColumnName("DATE_OF_REQUEST")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfReturning)
                    .HasColumnType("date")
                    .HasColumnName("DATE_OF_RETURNING");

                entity.Property(e => e.IsApproved).HasColumnName("IS_APPROVED");

                entity.Property(e => e.ReaderId).HasColumnName("READER_ID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__REQUEST__BOOK_ID__5441852A");

                entity.HasOne(d => d.Reader)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ReaderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__REQUEST__READER___5535A963");
            });
        }

    }
}
