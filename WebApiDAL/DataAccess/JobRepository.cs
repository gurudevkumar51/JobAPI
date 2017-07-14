using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.ServiceManager;
using WebApiDAL.Model;
using System.Data.Entity;

namespace WebApiDAL.DataAccess
{
    public class JobRepository : IJob
    {
        private WebphonixJobsDBEntities db = new WebphonixJobsDBEntities();

        //To Post new Job
        public Boolean PostJob(Tbl_Job job, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_Job.Add(job);
                db.SaveChanges();
                Tbl_JobActivity jobactivity = new Tbl_JobActivity();

                jobactivity.JobId = job.ID;
                jobactivity.Activity = "Job created by user ID" + job.UserID;
                jobactivity.ActivityDate = DateTime.Now;
                jobactivity.UserID = job.UserID;

                AddJobActivity(jobactivity);
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        //To Update posted Job
        public Boolean UpdateJob(Tbl_Job job, Tbl_JobActivity jobactivity, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                AddJobActivity(jobactivity);
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        //To Delete Posted Job
        public Boolean DeleteJob(int JobID, Tbl_JobActivity jobactivity, out string ErMsg)
        {
            ErMsg = "";
            try
            {
                var job = new Tbl_Job() { ID = JobID, IsActive = false };
                db.Tbl_Job.Attach(job);
                db.Entry(job).Property(x => x.IsActive).IsModified = true;
                db.SaveChanges();
                AddJobActivity(jobactivity);
                return true;
            }
            catch (Exception ex)
            {
                ErMsg = ex.Message;
                return false;
            }
        }

        //To Apply on Job
        public Boolean ApplyJob(Tbl_UserJob jobapply, out string ErMsg)
        {
            ErMsg = "";
            try
            {
                db.Tbl_UserJob.Add(jobapply);
                db.SaveChanges();
                Tbl_JobActivity jobactivity = new Tbl_JobActivity();

                jobactivity.Activity = "User ID" + jobapply.UserId + "Applied on Job Id:" + jobapply.JobId;
                jobactivity.ActivityDate = DateTime.Now;
                jobactivity.UserID = jobapply.UserId;
                jobactivity.JobId = jobapply.JobId;

                AddJobActivity(jobactivity);
                return true;
            }
            catch (Exception ex)
            {
                ErMsg = ex.Message;
                return false;
            }
        }

        private Boolean AddJobActivity(Tbl_JobActivity jbactivity)
        {
            //db.Tbl_JobActivity.Add(jbactivity);
            //db.SaveChanges();
            return true;
        }

        public IEnumerable<Tbl_Job> GetAllActiveJobs()
        {
            try
            {
                var jbs = db.Tbl_Job;
                return jbs.Where(j => j.IsActive == true).ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
