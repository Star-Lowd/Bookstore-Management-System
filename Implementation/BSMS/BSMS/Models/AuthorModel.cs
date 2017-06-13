using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class AuthorModel
    {
        private static bsms_service localhost = new bsms_service();
        internal static List<AUTHOR> GetAuthors()
        {
            return localhost.GetAuthors().ToList();
        }

        internal static AUTHOR Filter(int id)
        {
            foreach(AUTHOR auth in GetAuthors())
            {
                if (auth.AUTHORID == id)
                {
                    return auth;
                }
            }
            return null;
        }

        internal static void Create(AUTHOR author)
        {
            localhost.AddAuthor(author);
        }

        internal static void Update(AUTHOR author)
        {
            localhost.UpdateAuthor(author);
        }

        internal static void Delete(int id)
        {
            localhost.DeleteAuthor(id);
        }
    }
}