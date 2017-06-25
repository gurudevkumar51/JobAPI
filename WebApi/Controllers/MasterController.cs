using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDAL.DataAccess;
using WebApiDAL.Model;
using WebApiDAL.ServiceManager;

namespace WebApi.Controllers
{
    public class MasterController : ApiController
    {
        private IMaster Im;
        private string Ermsg = "";
        public MasterController()
        {
            Im = new MasterRepository();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Master/AddJobType")]
        public IHttpActionResult AddJobType(Tbl_JobType jobtpe)
        {
            if (jobtpe == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var flag = Im.AddJobType(jobtpe, out Ermsg);
                if (flag)
                {
                    return Json(new { success = true, responseText = "Job type Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Master/AddUserRole")]
        public IHttpActionResult AddRole(Tbl_UserRole role)
        {
            if (role == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var flag = Im.AddRole(role, out Ermsg);
                if (flag)
                {
                    return Json(new { success = true, responseText = "Role Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Master/AddSkill")]
        public IHttpActionResult AddSkill(Tbl_Skill skill)
        {
            if (skill == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var flag = Im.AddSkill(skill, out Ermsg);
                if (flag)
                {
                    return Json(new { success = true, responseText = "Skill Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Master/AddCurrency")]
        public IHttpActionResult AddCurrency(Tbl_Currency currency)
        {
            if (currency == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var flag = Im.AddCurrency(currency, out Ermsg);
                if (flag)
                {
                    return Json(new { success = true, responseText = "Currency Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Master/AddSocial")]
        public IHttpActionResult AddSocial(Tbl_SocialMedia social)
        {
            if (social == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var flag = Im.AddSocial(social, out Ermsg);
                if (flag)
                {
                    return Json(new { success = true, responseText = "Social media Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }
    }
}
