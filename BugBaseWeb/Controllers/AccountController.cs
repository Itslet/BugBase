using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugBaseClasses.Model;
using BugBaseClasses.Infrastructure;
using System.Web.Security;
using BugBaseClasses.Auth;

namespace BugBaseWeb.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(string email, string password, string returnUrl)
        {
            // Basic parameter validation
            if (String.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("email", "You must specify a mailaddress.");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "You must specify a password.");
            }

            if (ViewData.ModelState.IsValid)
            {

                BugBaseMembership provider = new BugBaseMembership();

                bool loginSuccessful = provider.ValidateUser(email, password);

                if (loginSuccessful)
                {
                    SetAuthenticationCookie(email);

                    return RedirectToAction("Create", "Bug");
                }

                else
                {
                    ModelState.AddModelError("_FORM", "The username or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form

            return View();

        }


        public virtual void SetAuthenticationCookie(string username)
        {
            FormsAuthentication.SetAuthCookie(username, false);
        }


        public void Logoff()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/");

        }

    }
}
