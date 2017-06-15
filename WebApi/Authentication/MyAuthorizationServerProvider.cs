using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApiDAL.DataAccess;
using WebApiDAL.Entity;
using WebApiDAL.ServiceManager;

namespace WebApi
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IAccount Acc;

        public MyAuthorizationServerProvider()
        {
            Acc = new AccountRepository();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            Login lgn = new Login();
            lgn.EmailId = context.UserName;
            lgn.Password = context.Password;
            var ErrMsg = "";
            var usr = Acc.Login(lgn, out ErrMsg);

            if (usr != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, usr.Role));
                identity.AddClaim(new Claim("email", usr.Email));
                identity.AddClaim(new Claim("PhoneNumber", usr.PhoneNumber));
                identity.AddClaim(new Claim("UserID", usr.ID.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, usr.PhoneNumber));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided Email and password is incorrect");
                return;
            }

            //if (context.UserName == "admin" && context.Password == "admin")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            //    identity.AddClaim(new Claim("username", "admin"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Gurudev kumar"));
            //    context.Validated(identity);
            //}
            //else if (context.UserName == "user" && context.Password == "user")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            //    identity.AddClaim(new Claim("username", "user"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Akhil"));
            //    context.Validated(identity);
            //}
        }
    }
}