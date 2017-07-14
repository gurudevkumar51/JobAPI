using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebApiDAL.DataAccess;
using WebApiDAL.Model;
using WebApiDAL.ServiceManager;

namespace WebApi.Controllers
{
    public class SeekerController : ApiController
    {
        private IAccount Acc;
        private ISeeker skr;
        private string Ermsg = "";
        public SeekerController()
        {
            Acc = new AccountRepository();
            skr = new SeekerRepository();
        }

        [Authorize(Roles = "seeker")]
        [HttpGet]
        [Route("api/Seeker/GetseekerDetails")]
        public IHttpActionResult GetseekerDetails()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var data = Acc.AllUserList().Where(u => u.UserID == Convert.ToInt32(identity.Name)).Select(p => new
            {
                UserID = p.UserID,
                certifications = p.Tbl_EducationDetails,
                experience = p.Tbl_ExperienceDetails,
                JobApplied = p.Tbl_UserJob
            });

            if (data == null)
            {
                return Json(new { success = false, responseText = "No Data found", responseCode = HttpStatusCode.InternalServerError });
            }
            else
            {
                return Json(new { success = true, responseText = data, responseCode = HttpStatusCode.OK });
            }
        }

        [Authorize(Roles = "seeker")]
        [HttpPost]
        [Route("api/Seeker/AddSeekerProfile")]
        public IHttpActionResult AddSeekerProfile(Tbl_SeekerProfile pro)
        {
            if (pro == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = skr.BuildProfile(pro, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "profile updated", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [Authorize(Roles = "seeker")]
        [HttpPost]
        [Route("api/Seeker/AddEducation")]
        public IHttpActionResult AddEducation(Tbl_EducationDetails edu)
        {
            if (edu == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = skr.AddEducation(edu, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [Authorize(Roles = "seeker")]
        [HttpPost]
        [Route("api/Seeker/AddExperience")]
        public IHttpActionResult AddExperience(Tbl_ExperienceDetails exp)
        {
            if (exp == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = skr.AddExperience(exp, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [Authorize(Roles = "seeker")]
        [HttpPost]
        [Route("api/Seeker/UpdateEducation")]
        public IHttpActionResult UpdateEducation(Tbl_EducationDetails edu)
        {
            if (edu == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = skr.UpdateEducation(edu, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [Authorize(Roles = "seeker")]
        [HttpPost]
        [Route("api/Seeker/UpdateExperience")]
        public IHttpActionResult UpdateExperience(Tbl_ExperienceDetails exp)
        {
            if (exp == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = skr.updateExperience(exp, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }
    }
}
