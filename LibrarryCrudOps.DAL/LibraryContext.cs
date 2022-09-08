using LibrarryCrudOps.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibrarryCrudOps.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
             .Property(e => e.Authors)
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
