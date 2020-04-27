using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationJWT.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Login(string userName, string password)
        {
            if(userName == "Admin" && password == "Password")
            {
                return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(userName));
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid userName or Password");
        }

        [CustomAuthenticationFIlter]
        public HttpResponseMessage GetEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Successfull.");
        }
    }
}
