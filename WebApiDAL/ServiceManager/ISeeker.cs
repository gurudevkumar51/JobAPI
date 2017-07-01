using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.Model;

namespace WebApiDAL.ServiceManager
{
    public interface ISeeker
    {
        Boolean BuildProfile(Tbl_SeekerProfile ProfileDetails, out string ErMsg);
        Boolean AddEducation(Tbl_EducationDetails EduDetails, out string ErMsg);
        Boolean AddExperience(Tbl_ExperienceDetails ExpDetails, out string ErMsg);

        //Boolean AddEducation(Tbl_EducationDetails edu, out string Ermsg);

        Boolean UpdateEducation(Tbl_EducationDetails edu, out string Ermsg);

        //Boolean AddExperience(Tbl_ExperienceDetails exp, out string Ermsg);

        Boolean updateExperience(Tbl_ExperienceDetails exp, out string Ermsg);
    }
}
