using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;

namespace WebApiDAL.DataAccess
{
    public class JobRepository : BaseRepository
    {
        //To Post new Job
        public Boolean PostJob(Job job, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        //To Update posted Job
        public Boolean UpdateJob(Job job, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        //To Delete Posted Job
        public Boolean DeleteJob(int jobID, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }

        //To Apply on Job
        public Boolean ApplyJob(JobActivity jobactivity, out string ErMsg)
        {
            ErMsg = "";
            return true;
        }
    }
}
