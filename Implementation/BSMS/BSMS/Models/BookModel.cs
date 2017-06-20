using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class BookModel
    {
        private static bsms_service Service = new bsms_service();

        public static int CountBookByAuthor(int? authorid)
        {
            return Service.GetBookAuthors().Where(bookA => bookA.AUTHORID == authorid.Value).Count();
        }

        public static List<BOOK> GetBooks()
        {
            return Service.GetBooks().ToList();
        }

        public static List<BOOK_IMAGE> GetBooksImages()
        {
            return Service.GetBookImages().ToList();
        }

        internal static BOOK AddBook(BOOK book)
        {
            return Service.InsertBook(book);
        }

        internal static IEnumerable<BOOK_CATEGORY> GetBookCategories()
        {
            return Service.GetBookCategories();
        }

        internal static void AddBookImage(BOOK_IMAGE bookImage)
        {
            Service.InsertBookImage(bookImage);
        }

        internal static void AddBookSoftCopy(BOOK_SOFTCOPY bSC)
        {
            Service.InsertBookSoftCopy(bSC);   
        }

        internal static BOOK FilterBook(int id)
        {
            foreach(BOOK book in GetBooks())
            {
                if (book.BOOKID == id)
                {
                    return book;
                }
            }
            return null;
        }
    }
}