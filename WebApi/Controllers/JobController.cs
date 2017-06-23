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
        public IHttpActionResult DeleteJob(int JbID, Tbl_JobActivity jobactivity)
        {
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
        public IHttpActionResult UpdateJob(Tbl_Job job, Tbl_JobActivity jobactivity)
        {
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
        public IHttpActionResult ApplyJob(Tbl_JobActivity jbactivity)
        {
            var flag = jb.ApplyJob(jbactivity, out Ermsg);
            if (flag)
            {
                return Json(new { success = true, responseText = "Job applied succesfully", responseCode = HttpStatusCode.Created });
            }
            else
            {
                return Json(new { success = flag, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
            }
        }
    }
}
