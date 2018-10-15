using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CreatingModel_MsSQL
{
    class CodeFirstContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BooksAuthors { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<BookAuthor>()
                .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<Author>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Book>()
                .HasQueryFilter(a => !a.IsDeleted);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(@"Server=[ip|Name]\SQLEXPRESS;Database=EF_CorePresentationCodeFirst;User Id=[user];Password=[password];MultipleActiveResultSets=True;");          
        }

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public bool IsDeleted { get; set; }

            public List<BookAuthor> BookAuthors { get; set; }
        }

        public class Author
        {
            public int AuthorId { get; set; }
            public string Name { get; set; }
            public AuthorImage AuthorImage { get; set; }
            public bool IsDeleted { get; set; }

            public List<BookAuthor> BookAuthors { get; set; }
        }

        public class BookAuthor
        {
            public int BookId { get; set; }
            public Book Book { get; set; }

            public int AuthorId { get; set; }
            public Author Author { get; set; }
        }
    }
}
