using BSMS.bsms.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSMS.Validator
{
    public class ContentValidator
    {
        public static String ValidBook(BOOK book)
        {
            return (!String.IsNullOrEmpty(book.NAME)) ? "Valid" : "Incorrect Book ISBN Number";
        }
    }
}
