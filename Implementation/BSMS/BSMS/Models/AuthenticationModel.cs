using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class AuthenticationModel
    {

        private static bsms_service services = new bsms_service();

        //Authenticate user
        internal static USER AuthenticateUser(String username , String password)
        {
            USER user = null;
            foreach(USER u in services.GetUsers())
            {
                if ((u.USERNAME == username || u.EMAIL == username) && MD5_Encoding.VerifyHash(password,u.PASSWORDHASH) )
                {
                    user = u;
                    break;
                }
            }

            return user;
        }

        internal static List<USER> GetStaffs()
        {
            return services.GetUsers().ToList();
        }

        internal static void DeleteUser(int id)
        {
            services.DeleteUser(id);
        }

        internal static void UpdateUser(USER user)
        {
            services.UpdateUser(user);
        }


        //insert new Users into the system
        internal static bool AddUser(USER user)
        {
            user.PASSWORDHASH = MD5_Encoding.Encode(user.PASSWORDHASH);
            return services.AddUser(user);
        }

        internal static bool EmailExist(string email)
        {
            foreach(USER u in services.GetUsers())
            {
                if (u.EMAIL.ToLower() == email.ToLower().Trim())
                {
                    return true;
                }
            }
            return false;
        }

        internal static bool VerifyUserHash(string hash)
        {
            foreach (USER u in services.GetUsers())
            {
                if (u.PASSWORDHASH.ToLower() == hash.ToLower().Trim())
                {
                    return true;
                }
            }
            return false;
        }

        internal static USER FindUser(int userID)
        {
            foreach (USER u in services.GetUsers())
            {
                if (u.USERID == userID)
                {
                    return u; ;
                }
            }
            return null;
        }

        internal static void ChangePassword(USER user)
        {
            user.PASSWORDHASH = MD5_Encoding.Encode(user.PASSWORDHASH);
            services.UpdateUser(user);
        }

        internal static USER FindUserByEmail(string email)
        {
            foreach (USER u in services.GetUsers())
            {
                if (u.EMAIL.ToLower() == email.ToLower())
                {
                    return u; ;
                }
            }
            return null;
        }
    }

 
}

