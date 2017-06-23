using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.ServiceManager;
using WebApiDAL.Model;
using System.Data.Entity;

namespace WebApiDAL.DataAccess
{
    public class AccountRepository : /*BaseRepository,*/ IAccount
    {
        private WebphonixJobsDBEntities db = new WebphonixJobsDBEntities();

        //Adding new User
        public Boolean RegisterUser(Tbl_User usr, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_User.Add(usr);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }            
        }

        //Change password if user exist & old password is correct 
        public Boolean ChangePassword(ChangePassword chp, string Eml, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                var usr = db.Tbl_User.Where(u => u.UserEmail == Eml).FirstOrDefault();
                if (usr == null)
                {
                    Ermsg = "User doesn't exit";
                }
                else
                {
                    if(usr.PassWord == chp.Password)
                    {
                        var user = new Tbl_User() { UserID = usr.UserID, PassWord = chp.NewPassword };
                        try
                        {
                            db.Tbl_User.Attach(user);
                            db.Entry(user).Property(x => x.AccountActive).IsModified = true;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Ermsg = ex.Message;
                        }
                    }
                    else
                    {
                        Ermsg = "Old password incorrect";
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        //Check Login
        public Tbl_User Login(Login lgn, out string ErrMsg)
        {
            ErrMsg = "";
            return db.Tbl_User.Where(p => p.UserEmail == lgn.EmailId && p.PassWord == lgn.Password).FirstOrDefault();             
        }

        //Update User Data
        public Boolean UpdateUser(Tbl_User usr, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Entry(usr).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }            
        }

        //Deactivate Account
        public Boolean DeactivateAccount(int UsrID, out string ErMsg)
        {
            ErMsg = "";
            var user = new Tbl_User() { UserID = UsrID, AccountActive = false };
            try
            {
                db.Tbl_User.Attach(user);
                db.Entry(user).Property(x => x.AccountActive).IsModified = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ErMsg = ex.Message;
                return false;
            }            
        }

        //List of All registered users
        public List<Tbl_User> AllUserList()
        {   
            return db.Tbl_User.ToList();
        }
    }
}
