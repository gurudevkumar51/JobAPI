using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Model;

namespace WebApiDAL.ServiceManager
{
    public interface IMaster
    {
        Boolean AddJobType(Tbl_JobType jobtype, out string Ermsg);
        Boolean AddRole(Tbl_UserRole role, out string Ermsg);
        Boolean AddCurrency(Tbl_Currency currency, out string Ermsg);
        Boolean AddSkill(Tbl_Skill skill, out string Ermsg);
        Boolean AddSocial(Tbl_SocialMedia social, out string Ermsg);
    }
}
