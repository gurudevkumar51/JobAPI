using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.Model;

namespace WebApiDAL.ServiceManager
{
    public interface IAccount
    {
        Boolean RegisterUser(Tbl_User usr, out string Ermsg);
        Boolean ChangePassword(ChangePassword chp, string Eml, out string Ermsg);
        Tbl_User Login(Login lgn, out string ErrMsg);
        Boolean UpdateUser(Tbl_User usr, out string Ermsg);
        Boolean DeactivateAccount(int UsrID, out string ErMsg);
        List<Tbl_User> AllUserList();
    }
}
