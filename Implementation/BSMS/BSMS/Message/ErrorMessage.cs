﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSMS.Message
{
    public class ErrorMessage
    {
        public const string INVALID_ACCESS = "404 This resources you looking for have been moved or you are not allow to view it";

        public const String FORGET_PASSWORD_EMAIL_MESSAGE = "Email Verification have been sent to your Email";
        internal static readonly dynamic EMAIL_ERROR_MESSAGE = "Email is Incorrect or it does not exist in our System!! <br/>Register Account With Us";
        internal static readonly dynamic INVALID_LOGIN = "Incorrect User Credential, Try again!!!";
        internal static readonly dynamic REQUIRED_ASTERIC_FIELDS = "* Fields are hightly required!!";
        internal static readonly dynamic PASSWORD_CHANGED = "There was a Problem Changing your Password, Go back to reset password page";
        internal static readonly dynamic INTERNAL_ERROR = "Internal Error Occured, Contact Development Team for more information";
        internal static readonly dynamic USER_UPDATED;
    }
}