using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;

namespace WebApiDAL.ServiceManager
{
    public interface IJob
    {
        Boolean PostJob(Job job, out string ErMsg);
        Boolean UpdateJob(Job job, JobActivity jobactivity, out string ErMsg);
        Boolean DeleteJob(JobActivity jobactivity, out string ErMsg);
        Boolean ApplyJob(JobActivity jobactivity, out string ErMsg);
    }
}
