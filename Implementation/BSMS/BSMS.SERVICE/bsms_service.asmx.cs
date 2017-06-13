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

    }
}
