using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class CategoryModel
    {
        private static bsms_service Services = new bsms_service();
        internal static void AddCategory(CATEGORY category)
        {
            Services.InserCategory(category);
        }

        public static List<CATEGORY> GetAllCategory()
        {
           return Services.GetCategories().ToList();
        }

        internal static void EditCategory(CATEGORY category)
        {
            Services.UpdateCategory(category);
        }

        internal static CATEGORY Fliter(int id)
        {
            foreach(CATEGORY cat in GetAllCategory())
            {
                if (cat.CATEGORYID == id)
                {
                    return cat;
                }
            }
            return null;
        }

        internal static void DeleteCategory(int id)
        {
            Services.DeleteCategory(id);
        }

        internal static void AddBookCategory(BOOK_CATEGORY bookCategory)
        {
            Services.InsertBookCategory(bookCategory);
        }
    }
}