using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.Model;
using WebApiDAL.ServiceManager;

namespace WebApiDAL.DataAccess
{
    public class SeekerRepository : /*BaseRepository,*/ ISeeker
    {
        private WebphonixJobsDBEntities db = new WebphonixJobsDBEntities();

        public Boolean BuildProfile(Tbl_SeekerProfile ProfileDetails, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_SeekerProfile.Add(ProfileDetails);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean UpdateProfile(Tbl_SeekerProfile ProfileDetails, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Entry(ProfileDetails).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean AddEducation(Tbl_EducationDetails EduDetails, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_EducationDetails.Add(EduDetails);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean EditEducation(Tbl_EducationDetails EduDetails, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Entry(EduDetails).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean DeleteEducation(int EduID, out string ErMsg)
        {
            ErMsg = "";
            try
            {
                Tbl_EducationDetails Edudetail = db.Tbl_EducationDetails.Find(EduID);
                db.Tbl_EducationDetails.Remove(Edudetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ErMsg = ex.Message;
                return false;
            }
        }

        public Boolean AddExperience(Tbl_ExperienceDetails ExpDetails, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_ExperienceDetails.Add(ExpDetails);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean EditExperience(Tbl_ExperienceDetails ExpDetails, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Entry(ExpDetails).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean DeleteExperience(int ExpID, out string ErMsg)
        {
            ErMsg = "";
            try
            {
                Tbl_ExperienceDetails Expdetail = db.Tbl_ExperienceDetails.Find(ExpID);
                db.Tbl_ExperienceDetails.Remove(Expdetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ErMsg = ex.Message;
                return false;
            }            
        }
    }
}
