﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDAL.Entity;
using WebApiDAL.ServiceManager;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private IAccount Acc;

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("api/User/AllUser")]
        public IHttpActionResult AllUser()
        {
            var pp = Acc.AllUserList();
            return Json(new { success = true, responseText = "Welcome", responseCode = HttpStatusCode.Created });
        }
    }
}
