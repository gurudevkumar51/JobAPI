using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;

namespace WebApiDAL.ServiceManager
{
    public interface IAccount
    {
        Boolean RegisterUser(User usr, out string Ermsg);
        Boolean ChangePassword(ChangePassword chp, string Eml, out string Ermsg);
        User Login(Login lgn, out string ErrMsg);
        Boolean UpdateUser(User usr, out string Ermsg);
        Boolean DeactivateAccount(int UsrID, out string ErMsg);
        List<User> AllUserList();
    }
}
