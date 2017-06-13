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

        public Boolean AddEducation(EducationDetails EduDetails, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        public Boolean AddExperience(ExperienceDetails ExpDetails, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }
    }
}
