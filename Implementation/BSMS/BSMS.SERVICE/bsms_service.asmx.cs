using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BSMS.SERVICE.App_Data;

namespace BSMS.SERVICE
{
    /// <summary>
    /// Summary description for bsms_service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class bsms_service : System.Web.Services.WebService
    {
        private DataAccessDataContext dataAccess = new DataAccessDataContext();
        [WebMethod]
        public void UpdateUser(USER user)
        {
            foreach (USER u in dataAccess.USERs.ToList())
            {
                if (u.USERID == user.USERID)
                {
                    u.FIRSTNAME = user.FIRSTNAME;
                    u.LASTNAME = user.LASTNAME;
                    u.MIDDLENAME = user.MIDDLENAME;
                    u.EMAIL = user.EMAIL;
                    u.THUMBNAIL_PATH = user.THUMBNAIL_PATH;
                }
            }
            dataAccess.SubmitChanges();
        }


        [WebMethod]
        public bool AddUser(USER user)
        {
            try
            {
                dataAccess.USERs.InsertOnSubmit(user);
                dataAccess.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public List<ROLE> GetRoles()
        {
            return dataAccess.ROLEs.ToList();
        }
        [WebMethod]
        public List<USER> GetUsers()
        {
            return dataAccess.USERs.ToList();
        }

        [WebMethod]

        public List<CATEGORY> GetCategories()
        {
            return dataAccess.CATEGORies.ToList();
        }

        [WebMethod]

        public void UpdateCategory(CATEGORY category)
        {
            foreach (CATEGORY cat in dataAccess.CATEGORies.ToList())
            {
                if (cat.CATEGORYID == category.CATEGORYID)
                {
                    cat.NAME = category.NAME;
                    cat.DESCRIPTION = category.DESCRIPTION;
                    cat.CATEGORY_THUMBNAIL = category.CATEGORY_THUMBNAIL;
                    cat.REFERENCE_KEY = category.REFERENCE_KEY;
                }
            }

            dataAccess.SubmitChanges();
        }

        [WebMethod]

        public void InserCategory(CATEGORY cat)
        {
            dataAccess.CATEGORies.InsertOnSubmit(cat);
            dataAccess.SubmitChanges();
        }

        [WebMethod]
        public void DeleteCategory(int catID)
        {
            CATEGORY cat = dataAccess.CATEGORies.ToList().Single(c => c.CATEGORYID == catID);
            dataAccess.CATEGORies.DeleteOnSubmit(cat);
            dataAccess.SubmitChanges();
        }


        [WebMethod]

        public List<GENRE> GetGenres()
        {
            return dataAccess.GENREs.ToList();
        }

        [WebMethod]

        public void UpdateGenre(GENRE genre)
        {
            foreach (GENRE gen in dataAccess.GENREs.ToList())
            {
                if (gen.GENREID == genre.GENREID)
                {
                    gen.NAME = genre.NAME;
                    gen.DESCRIPTION = genre.DESCRIPTION;
                    gen.REFERENCE_KEY = genre.REFERENCE_KEY;
                }
            }

            dataAccess.SubmitChanges();
        }

        [WebMethod]

        public void InserGenre(GENRE genre)
        {
            dataAccess.GENREs.InsertOnSubmit(genre);
            dataAccess.SubmitChanges();
        }

        [WebMethod]
        public void DeleteGenre(int genID)
        {
            GENRE gen = dataAccess.GENREs.ToList().Single(genre => genre.GENREID == genID);
            dataAccess.GENREs.DeleteOnSubmit(gen);
            dataAccess.SubmitChanges();
        }


        [WebMethod]
        public void DeleteUser(int uID)
        {
            USER gen = dataAccess.USERs.ToList().Single(user => user.USERID == uID);
            dataAccess.USERs.DeleteOnSubmit(gen);
            dataAccess.SubmitChanges();
        }


        [WebMethod]
        public List<AUTHOR> GetAuthors()
        {
            return dataAccess.AUTHORs.ToList();
        }


        [WebMethod]
        public void DeleteAuthor(int id)
        {
            AUTHOR author = dataAccess.AUTHORs.Single(aut => aut.AUTHORID == id);
            dataAccess.AUTHORs.DeleteOnSubmit(author);
            dataAccess.SubmitChanges();
        }

        [WebMethod]
        public void AddAuthor(AUTHOR author)
        {
            dataAccess.AUTHORs.InsertOnSubmit(author);
            dataAccess.SubmitChanges();
        }

        [WebMethod]
        public void UpdateAuthor(AUTHOR author)
        {
            AUTHOR prv = dataAccess.AUTHORs.Single(authors => authors.AUTHORID == author.AUTHORID);
            prv.ALIASNAME = author.ALIASNAME;
            prv.BIOGRAPHY = author.BIOGRAPHY;
            prv.FIRSTNAME = author.FIRSTNAME;
            prv.LASTNAME = author.LASTNAME;
            prv.MIDDLENAME = author.MIDDLENAME;
            prv.THUMBNAIL_PATH = author.THUMBNAIL_PATH;

            dataAccess.SubmitChanges();
        }

        [WebMethod]
        public List<PRODUCER> GetProducers()
        {
            return dataAccess.PRODUCERs.ToList();
        }

        [WebMethod]
        public void DeleteProducer(int id)
        {
            PRODUCER producer = dataAccess.PRODUCERs.Single(p => p.PRODUCERID == id);
            dataAccess.PRODUCERs.DeleteOnSubmit(producer);
            dataAccess.SubmitChanges();
        }


        [WebMethod]
        public void InsertProducer(PRODUCER producer)
        {
            dataAccess.PRODUCERs.InsertOnSubmit(producer);
            dataAccess.SubmitChanges();
        }

        [WebMethod]
        public void UpdateProducer(PRODUCER producer)
        {
            PRODUCER p = dataAccess.PRODUCERs.Single(pp => pp.PRODUCERID == producer.PRODUCERID);
            p.NAME = producer.NAME;
            p.EMAIL = producer.EMAIL;
            p.ADDRESS = producer.ADDRESS;
            p.CONTACT = producer.CONTACT;
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void InsertBook(BOOK book)
        {
            dataAccess.BOOKs.InsertOnSubmit(book);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void DeleteBook(int? bookid)
        {
            BOOK book = dataAccess.BOOKs.Single(b => b.BOOKID == bookid);
            dataAccess.BOOKs.DeleteOnSubmit(book);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void UpdateBook(BOOK book)
        {
            BOOK existingBook = dataAccess.BOOKs.Single(b => b.BOOKID == book.BOOKID);
            
            //existingBook.NAME = book.NAME;
            //existingBook.ISBN_NUMBER = book.ISBN_NUMBER;
            // existingBook.STATUS = book.STATUS;
            // existingBook.SYNOPOSIS = book.SYNOPOSIS;
            // existingBook.ISPUBLISHED = book.ISPUBLISHED;
            // existingBook.REFERENCE = book.REFERENCE;
            // existingBook.DATE_PUBLISHED = book.DATE_PUBLISHED;
            // existingBook.CREATED_DATE = book.CREATED_DATE;
            existingBook = book;
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public List<BOOK> GetBooks()
        {
            return dataAccess.BOOKs.ToList();
        }

        //book images
        [WebMethod]
        public void InsertBookImage(BOOK_IMAGE image)
        {
            dataAccess.BOOK_IMAGEs.InsertOnSubmit(image);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void UpdateBookImage(BOOK_IMAGE image)
        {
            BOOK_IMAGE bookImage = dataAccess.BOOK_IMAGEs.Single(bi => bi.BOOKID == image.BOOKID);
            bookImage = image;
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void DeleteBookImage(int id)
        {
            BOOK_IMAGE bookImage = dataAccess.BOOK_IMAGEs.Single(bi => bi.BOOKID == id);
            dataAccess.BOOK_IMAGEs.DeleteOnSubmit(bookImage);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public List<BOOK_IMAGE> GetBookImages()
        {
            return dataAccess.BOOK_IMAGEs.ToList();
        }


        //book category
        [WebMethod]
        public void InsertBookCategory(BOOK_CATEGORY bCategory)
        {
            dataAccess.BOOK_CATEGORies.InsertOnSubmit(bCategory);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void UpdateBookCategory(BOOK_CATEGORY bCategory)
        {
            BOOK_CATEGORY bookCategory = dataAccess.BOOK_CATEGORies.Single(bc => bc.BOOK_CATEGORYID == bCategory.BOOK_CATEGORYID);
            bookCategory = bCategory;
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void DeleteBookCategory(int? bCategoryID)
        {
            BOOK_CATEGORY bookCategory = dataAccess.BOOK_CATEGORies.Single(bc => bc.BOOK_CATEGORYID == bCategoryID);
            dataAccess.BOOK_CATEGORies.DeleteOnSubmit(bookCategory);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public List<BOOK_CATEGORY> GetBookCategories() {
            return dataAccess.BOOK_CATEGORies.ToList(); 
        }


        //book author
        [WebMethod]
        public void InsertBookAuthor(BOOK_AUTHOR author)
        {
            dataAccess.BOOK_AUTHORs.InsertOnSubmit(author);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void UpdateBookAuthor(BOOK_AUTHOR bAuthor)
        {
            BOOK_AUTHOR bookAuthor = dataAccess.BOOK_AUTHORs.Single(ba => ba.AUTHORID== bAuthor.AUTHORID);
            bookAuthor = bAuthor;
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void DeleteBookAuthor(int? bAuthorID)
        {
            BOOK_AUTHOR bookAuthor = dataAccess.BOOK_AUTHORs.Single(bAuthor => bAuthor.AUTHORID == bAuthorID);
            dataAccess.BOOK_AUTHORs.DeleteOnSubmit(bookAuthor);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public List<BOOK_AUTHOR> GetBookAuthors()
        {
            return dataAccess.BOOK_AUTHORs.ToList();
        }

        //book SoftCopy
        [WebMethod]
        public void InsertBookSoftCopy(BOOK_SOFTCOPY copy)
        {
            dataAccess.BOOK_SOFTCOPies.InsertOnSubmit(copy);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void UpdateBookSoftCopy(BOOK_SOFTCOPY bSoftCopy)
        {
            BOOK_SOFTCOPY bookSoftCopy = dataAccess.BOOK_SOFTCOPies.Single(bSC => bSC.BSCID == bSoftCopy.BSCID);
            bookSoftCopy = bSoftCopy;
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public void DeleteBookSoftCopy(int? bSCID)
        {
            BOOK_SOFTCOPY bookSoftCopy = dataAccess.BOOK_SOFTCOPies.Single(bSoftCopy => bSoftCopy.BSCID == bSCID);
            dataAccess.BOOK_SOFTCOPies.DeleteOnSubmit(bookSoftCopy);
            dataAccess.SubmitChanges();
        }
        [WebMethod]
        public List<BOOK_SOFTCOPY> GetBookSoftCopy()
        {
            return dataAccess.BOOK_SOFTCOPies.ToList();
        }


    }
}
