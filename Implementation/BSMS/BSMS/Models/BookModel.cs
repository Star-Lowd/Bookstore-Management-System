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


        public static List<BOOK_SOFTCOPY> getBookSoftCopy(int bookid)
        {
            return Service.GetBookSoftCopy().Where(bCopy => bCopy.BOOKID == bookid).ToList();
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

        internal static void DeleteBook(int id)
        {
            foreach(BOOK_AUTHOR bAuthors in Service.GetBookAuthors().Where(bA=>bA.BOOKID == id))
            {
                Service.DeleteBookAuthor(bAuthors.BOOK_AUTHORID);
            }
            foreach (BOOK_CATEGORY bCategory in Service.GetBookCategories().Where(bC => bC.BOOKID == id))
            {
                Service.DeleteBookCategory(bCategory.BOOK_CATEGORYID);
            }
            foreach (BOOK_IMAGE bImage in Service.GetBookImages().Where(bI => bI.BOOKID == id))
            {
                Service.DeleteBookImage(bImage.BOOK_IMAGEID);
            }
            foreach (BOOK_SOFTCOPY bCopy in Service.GetBookSoftCopy().Where(bS => bS.BOOKID == id))
            {
                Service.DeleteBookSoftCopy(bCopy.BSCID);
            }
            foreach (WATCHLIST watchlist in Service.GetAllWishList().Where(bS => bS.BOOKID == id))
            {
                Service.DeleteWishList(watchlist.WATCHLISTID);
            }
            Service.DeleteBook(id);
        }
    }
}