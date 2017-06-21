using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;

namespace WebApiDAL.ServiceManager
{
    public interface ISeeker
    {
        Boolean BuildProfile(SeekerProfile ProfileDetails, out string ErMsg);
        Boolean AddEducation(EducationDetails EduDetails, out string ErMsg);
        Boolean AddExperience(ExperienceDetails ExpDetails, out string ErMsg);
    }
}
