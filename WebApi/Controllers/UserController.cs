using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDAL.DataAccess;
using WebApiDAL.Entity;
using WebApiDAL.ServiceManager;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private IAccount Acc;

        public UserController()
        {
            Acc = new AccountRepository();
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/User/AllUser")]
        public IHttpActionResult AllUser()
        {            
            var data = Acc.AllUserList().Where(u => u.AccountActive==true).Select(p => new
            {
                UserID = p.UserID,
                Email = p.UserEmail,
                phone = p.PhoneNumber,
                ProfileImage = p.ProfileImgPath,
                RoleId = p.RoleID,
                Role = p.Tbl_UserRole.Role,
                RegistrationDate = p.RegistrationDate
            }).ToList();
            return Json(new { success = true, responseData = data, responseCode = HttpStatusCode.OK });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/User/SeekerCount")]
        public IHttpActionResult SeekerCount()
        {
            int data = Acc.AllUserList().Where(p => p.AccountActive == true && p.RoleID == 3).ToList().Count;
            return Json(new { success = true, responseData = data, responseCode = HttpStatusCode.OK });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/User/EmployerCount")]
        public IHttpActionResult EmployerCount()
        {
            int data = Acc.AllUserList().Where(p => p.AccountActive == true && p.RoleID == 2).ToList().Count;
            return Json(new { success = true, responseData = data, responseCode = HttpStatusCode.OK });
        }
    }
}
