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
        private ISeeker skr;
        private IEmployer cmp;
        private string Ermsg = "";
        public AccountController()
        {
            Acc = new AccountRepository();
            skr = new SeekerRepository();
            cmp = new EmployerRepository();
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

        [Authorize]
        [HttpGet]
        [Route("api/Account/GetUserDetails")]
        public IHttpActionResult GetUserDetails()
        {
            var identity = (ClaimsIdentity)User.Identity;

           var data = Acc.AllUserList().Where(u => u.UserID == Convert.ToInt32(identity.Name)).Select(p => new
            {
                UserID = p.UserID,
                Email = p.UserEmail,
                phone = p.PhoneNumber,
                ProfileImage = p.ProfileImgPath,
                RoleId = p.RoleID,
                Role = p.Tbl_UserRole.Role,                
                RegistrationDate =p.RegistrationDate
            });

            if (data==null)
            {                
                return Json(new { success = false, responseText = "No Data found", responseCode = HttpStatusCode.InternalServerError });
            }
            else
            {
                return Json(new { success = true, responseText = data, responseCode = HttpStatusCode.OK });
            }              
        }
                
        //For testing purpose only
        [Authorize(Roles = "employer")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }
    }
}
