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
        Boolean AddRole(Tbl_JobType jobtype, out string Ermsg);
    }
}
