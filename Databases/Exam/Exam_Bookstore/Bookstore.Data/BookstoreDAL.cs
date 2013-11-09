using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class BookstoreDAL
    {
        public static void AddBook(string author, string title, string isbn, string price, string website)
		{
			BookstoreEntities context = new BookstoreEntities();
                      
			Book newBook = new Book();
            
            newBook.Authors.Add(CreateOrLoadAuthor(context, author));
            newBook.Title = title.Trim();
            if (isbn != null)
            {
                newBook.ISBN = long.Parse(isbn.Trim());
            }

            if (price != null)
            {
                newBook.Price = decimal.Parse(price.Trim());
            }

            context.Books.Add(newBook);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
            }
		}

        private static Author CreateOrLoadAuthor(BookstoreEntities context, string author)
        {
            Author existingAuthor =
                (from a in context.Authors
                 where a.AuthorName.ToLower() == author.ToLower()
                 select a).FirstOrDefault();

            if (existingAuthor != null)
            {
                return existingAuthor;
            }

            Author newAuthor = new Author();
            
            newAuthor.AuthorName = author;

            context.Authors.Add(newAuthor);
            context.SaveChanges();

            return newAuthor;
        }

        public static void AddBookComplex(List<string> authors, string title, string isbn, string price, string website)
        {
            BookstoreEntities context = new BookstoreEntities();

            Book newBook = new Book();

            foreach (var author in authors)
            {
                newBook.Authors.Add(CreateOrLoadAuthor(context, author));    
            }
            
            newBook.Title = title.Trim();
            if (isbn != null)
            {
                newBook.ISBN = long.Parse(isbn.Trim());
            }

            if (price != null)
            {
                newBook.Price = decimal.Parse(price.Trim());
            }
            
            context.Books.Add(newBook);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
            }

        }

        private static Review CreateReview(BookstoreEntities context, string review)
        {
            Review newReview = new Review();

            newReview.Notes=review;

            context.Reviews.Add(newReview);
            context.SaveChanges();

            return newReview;
        }

        

        public static IList<Book> FindBookByTitleAuthorOrISBN(string authorname, string title, string isbn)
        {
            BookstoreEntities context = new BookstoreEntities();
            

            ICollection<Book> booksByAuthor = new ICollection<Book>();

            if (authorname != null)
            {
                booksByAuthor =
                   (from a in context.Authors
                    where a.AuthorName == authorname
                    select a).FirstOrDefault().Books;

                
            }
            else {
                booksByAuthor =
                    (from b in context.Books
                     select b).ToList();
                
            }

            if (title != null)
            {
                booksByAuthor =
                    (from b in context.Books
                    where b.Title Equals title
                    select b);

                
            }

         //if (isbn != null)
         //{
         //    booksQuery =
         //      from b in context.Books
         //      where b.ISBN == isbn
         //      select b;
         //}

            return booksByAuthor.ToList();
        }
        

    }
}
