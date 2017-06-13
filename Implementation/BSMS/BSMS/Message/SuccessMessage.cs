using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSMS.Message
{
    public class SuccessMessage
    {
        internal static readonly dynamic CATEGORY_ADDED = "New Category have been successfully added";
        internal static readonly dynamic CATEGORY_EDITED = "Information of Category Have been successfully Updated";
        internal static readonly dynamic EMAIL_SENT= "Email Notification have been sent to your Email";
        internal static readonly dynamic PASSWORD_CHANGED = "Your password have been successfully changed <br/>This will redirect you to login page";
        internal static readonly dynamic REGISTERATION_COMPLETED = "Registration Successful";
    }
}