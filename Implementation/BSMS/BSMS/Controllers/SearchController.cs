using BSMS.bsms.localhost;
using BSMS.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(int id=-1, String query="",int page=1, int pageSize=4)
        {
            
            List<BOOK> books = new List<BOOK>();
            if (id == -1 && query == "")
            {
                books = BookModel.GetBooks();
            }
            else if (id != -1 && query != "")
            {
                IEnumerable<BOOK_CATEGORY> bookCat = BookModel.GetBookCategories();
                foreach(BOOK_CATEGORY bCat in bookCat)
                {
                    if (bCat.CATEGORYID == id && bCat.BOOK.NAME.ToLower().Contains(query.ToLower()))
                    {
                        books.Add(bCat.BOOK);
                    }
                }
            }
            else if (id == -1 && query != "")
            {
                IEnumerable<BOOK> listBooks = BookModel.GetBooks();
                foreach (BOOK book in listBooks)
                {
                    if (book.NAME.ToLower().Contains(query.ToLower()))
                    {
                        books.Add(book);
                    }
                }
            }
            IPagedList<BOOK> pBooks = new PagedList<BOOK>(books, page, pageSize);
            return View(pBooks);
        }

    }
}