using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.ServiceManager;

namespace WebApiDAL.DataAccess
{
    public class AccountRepository : BaseRepository, IAccount
    {
        public Boolean RegisterUser(User usr, out string Ermsg)
        {
            Ermsg = "";
            return true;
        }

        public Boolean ChangePassword(ChangePassword chp, string Eml, out string Ermsg)
        {
            Ermsg = "";
            return true;
        }

        public User Login(Login lgn, out string ErrMsg)
        {
            ErrMsg = "";
            var pp = AllUserList().FirstOrDefault();
            return pp;
        }

        public Boolean UpdateUser(User usr, out string Ermsg)
        {
            Ermsg = "";
            return true;
        }

        public Boolean DeactivateAccount(int UsrID, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        public List<User> AllUserList()
        {
            List<User> users = new List<User>();
            User u = new User();
            u.ID = 1;
            u.Email = "gurudevkumar51@hotmail.com";
            u.Password = "123";
            u.Role = "admin";
            u.PhoneNumber = "1234567896";

            users.Add(u);
            return users;
        }
    }
}
