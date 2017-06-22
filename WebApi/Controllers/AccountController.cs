using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebApiDAL.DataAccess;
using WebApiDAL.Entity;
using WebApiDAL.ServiceManager;
using WebApiDAL.Model;

namespace WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private IAccount Acc;
        private string Ermsg = "";
        public AccountController()
        {
            Acc = new AccountRepository();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Account/Register")]
        public IHttpActionResult RegisterUser(Tbl_User usr)
        {
            if (usr == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = Acc.RegisterUser(usr, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "Welcome", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Account/ChangePassword")]
        public IHttpActionResult ChangePassword(ChangePassword chP)
        {
            var identity = (ClaimsIdentity)User.Identity;
            if (chP == null)
            {
                return Json(new { success = false, responseText = "Send proper data", responseCode = HttpStatusCode.BadRequest });
            }
            else
            {
                var pp = Acc.ChangePassword(chP, identity.FindFirst("email").Value, out Ermsg);
                if (pp)
                {
                    return Json(new { success = true, responseText = "Welcome", responseCode = HttpStatusCode.Created });
                }
                else
                {
                    return Json(new { success = false, responseText = Ermsg, responseCode = HttpStatusCode.InternalServerError });
                }
            }
        }
    }
}
