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
        [Route("api/Master/Add")]
        public IHttpActionResult AddJobType(Tbl_JobType jobtpe)
        {
            if (jobtpe == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = Im.AddRole(jobtpe, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "Job type Added", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }
    }
}
