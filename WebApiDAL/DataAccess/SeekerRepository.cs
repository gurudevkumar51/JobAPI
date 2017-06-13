using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;

namespace WebApiDAL.DataAccess
{
    public class SeekerRepository:BaseRepository
    {
        public Boolean BuildProfile(SeekerProfile ProfileDetails, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        public Boolean UpdateProfile(SeekerProfile ProfileDetails, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        public Boolean AddEducation(EducationDetails EduDetails, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        public Boolean EditEducation(EducationDetails EduDetails, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        public Boolean DeleteEducation(int EduID, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }


        public Boolean AddExperience(ExperienceDetails ExpDetails, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        public Boolean EditExperience(ExperienceDetails ExpDetails, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        public Boolean DeleteExperience(int ExpID, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }
    }
}
