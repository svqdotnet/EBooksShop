using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static CreatingModel_MsSQL.CodeFirstContext;

namespace CreatingModel_MsSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CodeFirstContext())
            {

                //creamos y guardamos los autores
                var author1 = new Author { Name = "Arturo Perez Reverte", IsDeleted = false };
                var author2 = new Author { Name = "Carlos Ruiz Zafón", IsDeleted = false };
                var author3 = new Author { Name = "Daniel Defoe", IsDeleted = false };
                var author4 = new Author { Name = "El negro de Arturo", IsDeleted = false };

                db.Authors.Add(author1);
                var imageAuthor1 = new AuthorImage { Title = "Imagen Arturito" };
                author1.AuthorImage = imageAuthor1;
                db.Authors.Add(author2);
                db.Authors.Add(author3);
                db.Authors.Add(author4);


                //creamos y guardamos los libros
                var book1 = new Book { Title = "La tabla de Flandes", IsDeleted = false };
                var book2 = new Book { Title = "La piel del tambor", IsDeleted = false };
                var book3 = new Book { Title = "Robinson Crusoe", IsDeleted = false };
                var book4 = new Book { Title = "El juego del ángel", IsDeleted = false };
                db.Books.Add(book1);
                db.Books.Add(book2);
                db.Books.Add(book3);
                db.Books.Add(book4);                


                //creamos y guardamos la tabla "intermedia"
                db.BooksAuthors.Add(new BookAuthor { AuthorId = author1.AuthorId, BookId = book1.BookId });
                db.BooksAuthors.Add(new BookAuthor { AuthorId = author4.AuthorId, BookId = book1.BookId });
                db.BooksAuthors.Add(new BookAuthor { AuthorId = author2.AuthorId, BookId = book4.BookId });
                db.BooksAuthors.Add(new BookAuthor { AuthorId = author1.AuthorId, BookId = book2.BookId });
                db.BooksAuthors.Add(new BookAuthor { AuthorId = author3.AuthorId, BookId = book3.BookId });
                //try
                //{
                //    db.SaveChanges();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.InnerException.Message);
                //}

                var eagerLoading = db.BooksAuthors.Include(x => x.Author).Include(y => y.Book).ToList();

                foreach (var author in db.Authors)
                {
                    Console.WriteLine(author.Name + " has written:");

                    if (author.BookAuthors != null)
                    {
                        var books = author.BookAuthors.Select(x => x.Book).ToList();

                        foreach (var book in books)
                        {
                            Console.WriteLine("- " + book.Title);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sin libros registrados");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("-----------------------------------------------------");
                var authorFilterByName = (from a in db.Authors
                                          where EF.Functions.Like(a.Name, "a%")
                                          select a).ToList();

                foreach (var autores in authorFilterByName)
                {
                    Console.WriteLine(autores.Name);
                }

                //Console.WriteLine("-----------------------------------------------------");
                Console.ReadLine();



            } //fin del using 


            

            Console.ReadLine();
        }
    }
}
