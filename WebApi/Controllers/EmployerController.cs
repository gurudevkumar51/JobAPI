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
    public class EmployerController : ApiController
    {
        private IAccount Acc;
        private IEmployer cmp;
        private string Ermsg = "";
        public EmployerController()
        {
            Acc = new AccountRepository();
            cmp = new EmployerRepository();            
        }

        [Authorize(Roles = "employer")]
        [HttpGet]
        [Route("api/data/GetEmployerDetails")]
        public IHttpActionResult GetEmployerDetails()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var data = Acc.AllUserList().Where(u => u.UserID == Convert.ToInt32(identity.Name)).Select(p => new
            {
                UserID = p.UserID,
                profile = p.Tbl_EmployerProfile
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

        [Authorize(Roles = "employer")]
        [HttpPost]
        [Route("api/Seeker/AddEmployerProfile")]
        public IHttpActionResult AddEmployerProfile(Tbl_EmployerProfile pro)
        {
            if (pro == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = cmp.AddCompanyProfile(pro, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "profile Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [Authorize(Roles = "employer")]
        [HttpPost]
        [Route("api/Seeker/UpdateEmployerProfile")]
        public IHttpActionResult UpdateEmployerProfile(Tbl_EmployerProfile pro)
        {
            if (pro == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = cmp.UpdateCompanyProfile(pro, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "profile Updated", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }
    }
}
