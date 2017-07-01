using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.Model;

namespace WebApiDAL.ServiceManager
{
    public interface IJob
    {
        Boolean PostJob(Tbl_Job job, out string ErMsg);
        Boolean UpdateJob(Tbl_Job job, Tbl_JobActivity jobactivity, out string ErMsg);
        Boolean DeleteJob(int job, Tbl_JobActivity jobactivity, out string ErMsg);
        Boolean ApplyJob(Tbl_UserJob jobapply, out string ErMsg);
        IEnumerable<Tbl_Job> GetAllActiveJobs();
    }
}
