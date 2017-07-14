using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDAL.DataAccess;
using WebApiDAL.Entity;
using WebApiDAL.Model;
using WebApiDAL.ServiceManager;

namespace WebApi.Controllers
{
    public class JobController : ApiController
    {
        private IJob jb;
        private string Ermsg = "";
        public JobController()
        {
            jb = new JobRepository();
        }

        [Authorize(Roles = "employer")]
        [HttpPost]
        [Route("api/Job/Add")]
        public IHttpActionResult AddJob(Tbl_Job job)
        {            
            var flag = jb.PostJob(job, out Ermsg);
            if (flag)
            {
                return Json(new { success = true, responseText = "Job added succesfully", responseCode = HttpStatusCode.Created });
            }
            else
            {
                return Json(new { success = flag, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
            }            
        }

        [Authorize(Roles = "employer")]
        [HttpPost]
        [Route("api/Job/Delete")]
        public IHttpActionResult DeleteJob(int JbID)
        {
            Tbl_JobActivity jobactivity = new Tbl_JobActivity();
            var flag = jb.DeleteJob(JbID, jobactivity, out Ermsg);
            if (flag)
            {
                return Json(new { success = true, responseText = "Job deleted succesfully", responseCode = HttpStatusCode.Created });
            }
            else
            {
                return Json(new { success = flag, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
            }
        }

        [Authorize(Roles = "employer")]
        [HttpPost]
        [Route("api/Job/Edit")]
        public IHttpActionResult UpdateJob(Tbl_Job job)
        {
            Tbl_JobActivity jobactivity = new Tbl_JobActivity();
            var flag = jb.UpdateJob(job, jobactivity, out Ermsg);
            if (flag)
            {
                return Json(new { success = true, responseText = "Job updated succesfully", responseCode = HttpStatusCode.Created });
            }
            else
            {
                return Json(new { success = flag, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
            }
        }

        [Authorize(Roles = "seeker")]
        [HttpPost]
        [Route("api/Job/Apply")]
        public IHttpActionResult ApplyJob(Tbl_UserJob jobapply)
        {
            var flag = jb.ApplyJob(jobapply, out Ermsg);
            if (flag)
            {
                return Json(new { success = true, responseText = "Job applied succesfully", responseCode = HttpStatusCode.Created });
            }
            else
            {
                return Json(new { success = flag, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
            }
        }

        [AllowAnonymous]
        [Route("api/Job/AllJobs")]
        public IHttpActionResult GetJobs()  
        {
            //List<Tbl_Job> allActiveJobs = jb.GetAllActiveJobs().ToList();
            var data = jb.GetAllActiveJobs().Select(p => new
            {
                id=p.ID,
                UserID = p.UserID
               ,JobTypeID=p.JobTypeID
      ,CreatedDate=p.CreatedDate
      ,JobDescription=p.JobDescription
      ,JobLocation=p.JobLocation
      ,MinExperienceRequired=p.MinExperienceRequired
      ,MaxExperienceRequired=p.MaxExperienceRequired
      ,ExpireDate=p.ExpireDate
      ,IsActive=p.IsActive
            });


            return Json(new { success = true, responseText = data, responseCode = HttpStatusCode.OK });

            //return Json(allActiveJobs);            
        }

        [AllowAnonymous]
        [Route("api/Job/Job")]
        public IHttpActionResult GetJob(int id)
        {
            //List<Tbl_Job> allActiveJobs = jb.GetAllActiveJobs().ToList();
            var data = jb.GetAllActiveJobs().Where(j => j.ID == id).Select(p => new
            {
                id = p.ID,
                UserID = p.UserID,
                JobTypeID = p.JobTypeID,
                CreatedDate = p.CreatedDate,
                JobDescription = p.JobDescription,
                JobLocation = p.JobLocation,
                MinExperienceRequired = p.MinExperienceRequired,
                MaxExperienceRequired = p.MaxExperienceRequired,
                ExpireDate = p.ExpireDate,
                IsActive = p.IsActive
            }).FirstOrDefault();
            return Json(new { success = true, responseText = data, responseCode = HttpStatusCode.OK });

            //return Json(allActiveJobs);            
        }
    }
}
