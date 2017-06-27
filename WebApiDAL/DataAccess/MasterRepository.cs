using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Model;
using WebApiDAL.ServiceManager;

namespace WebApiDAL.DataAccess
{
    public class MasterRepository : IMaster
    {
        private WebphonixJobsDBEntities db = new WebphonixJobsDBEntities();

        public Boolean AddJobType(Tbl_JobType jobtype, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_JobType.Add(jobtype);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean AddRole(Tbl_UserRole role, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_UserRole.Add(role);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean AddCurrency(Tbl_Currency currency, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_Currency.Add(currency);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean AddSkill(Tbl_Skill skill, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_Skill.Add(skill);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean AddSocial(Tbl_SocialMedia social, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_SocialMedia.Add(social);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }
    }
}
