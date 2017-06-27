using BSMS.bsms.localhost;
using BSMS.Message;
using BSMS.Models;
using BSMS.Utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BSMS.Controllers
{
    public class BookController : Controller
    {

        private void initialiseViewBag()
        {
            ViewBag.Authors = new MultiSelectList(AuthorModel.GetAuthors(), "AUTHORID", "ALIASNAME");
            ViewBag.PRODUCERID = new SelectList(ProducerModel.GetProducers(), "PRODUCERID", "NAME");
            ViewBag.Categories = new MultiSelectList(CategoryModel.GetAllCategory(), "CATEGORYID", "NAME");
            ViewBag.GENREID = new SelectList(GenreModel.GetGenre(), "GENREID", "NAME");
            ViewBag.LANGUAGEID = new SelectList(LanguageModel.GetLanguages(), "LANGUAGEID", "LANGUAGE1");
            ViewBag.TRANSLATEDFROM = new SelectList(BookModel.GetBooks(), "BOOKID", "NAME");
        }
        public ActionResult Index()
        {
            return View(BookModel.GetBooks());
        }

        public ActionResult AddBook()
        {
            initialiseViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(BOOK book, List<int> Authors, List<int> Categories, 
            List<HttpPostedFileBase> bookImages, List<HttpPostedFileBase> bookSoftCopy)
        {
            try
            {
                book.CREATED_DATE = DateTime.Now;
                book = BookModel.AddBook(book);

                foreach(int aID in Authors)
                {
                    BOOK_AUTHOR bookAuthor = new BOOK_AUTHOR();
                    bookAuthor.BOOKID = book.BOOKID;
                    bookAuthor.AUTHORID = aID;
                    AuthorModel.AddBookAuthor(bookAuthor);
                }

                foreach (int bCID in Categories)
                {
                    BOOK_CATEGORY bookCat = new BOOK_CATEGORY();
                    bookCat.BOOKID = book.BOOKID;
                    bookCat.CATEGORYID = bCID;
                    CategoryModel.AddBookCategory(bookCat);
                }

                foreach(HttpPostedFileBase image in bookImages)
                {
                   
                        String fname = Generator.RandomString(10) + "." + image.FileName.Split('.')[image.FileName.Split('.').Length - 1];
                        string path = Server.MapPath("~/UserImages/") + fname;
                        BOOK_IMAGE bookImage = new BOOK_IMAGE();
                        bookImage.BOOKID = book.BOOKID;
                        bookImage.IMAGEPATH = "/UserImages/" + fname;
                        image.SaveAs(path);
                        BookModel.AddBookImage(bookImage);
                   
                }
                if (bookSoftCopy != null)
                {

                    foreach (HttpPostedFileBase bookSC in bookSoftCopy)
                    {
                        String fname = Generator.RandomString(10) + "." + bookSC.FileName.Split('.')[bookSC.FileName.Split('.').Length - 1];
                        string path = Server.MapPath("~/UserImages/") + fname;
                        BOOK_SOFTCOPY bSC = new BOOK_SOFTCOPY();
                        bSC.BOOKID = book.BOOKID;
                        bSC.FILEPATH = "/UserImages/" + fname;
                        bSC.FILESIZE = bookSC.ContentLength;
                        bookSC.SaveAs(path);
                        BookModel.AddBookSoftCopy(bSC);

                    }

                }
                ViewBag.Message = SuccessMessage.BOOK_ADDED;

            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
            }
            initialiseViewBag();
            return View();
        }

        public ActionResult BookList(int page = 1, int pageSize=6)
        {
            IPagedList<BOOK> books = new PagedList<BOOK>(BookModel.GetBooks(), page,pageSize);
            return View(books);
        }

        public ActionResult BookDetail(int id)
        {
            BOOK book = BookModel.FilterBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(book);
            }
        }


        public ActionResult Delete(int id)
        {
            BookModel.DeleteBook(id);
            return null;
        }

        public ActionResult Detail(int id)
        {
            BOOK book = BookModel.FilterBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }
    }
}