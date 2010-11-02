using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Norm.Linq;
using Norm;
using BugBaseClasses.Infrastructure;
using BugBaseClasses.Model;
using BugBaseClasses.Auth;


namespace BugBaseWeb.Controllers
{
    public class BugController : Controller
    {
        //
        // GET: /Bug/

        public ActionResult Index(object id)
        {

            string identifier = id.ToString();
            var BugSession = new MongoSession<Bug>();
            try
                
            {
                var bugsies = BugSession.Queryable.AsEnumerable();
                var dezebugs = bugsies.Where(p => p.BugProject.Id == (Norm.ObjectId)identifier);
                var bug = bugsies.Where(p => p.BugProject.Id == (Norm.ObjectId)identifier).FirstOrDefault();

                ViewData["Name"] = bug.BugProject.ProjectName;

                int k = dezebugs.Count();


                if ( k != 0)
                {
                    return View(dezebugs);
                }
                else
                {
                    ViewData["Error"] = "No bugs submitted for this project";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Error: " + ex.Message;
                return View();
            }

        }

        [RequiresAuthentication]
        public ActionResult Create(ObjectId id)
        {

            return View();
        }
    
        [RequiresAuthentication]
        [HttpPost]
    public ActionResult Create(Bug bug)
        {
            var BugSession = new MongoSession<Bug>();
            var UserSession = new MongoSession<User>();
            var ProjectSession = new MongoSession<BugProject>();
          
            var gebr = UserSession.Queryable.AsEnumerable();
            var bugpr = ProjectSession.Queryable.AsEnumerable();
            string id = "51495c0264489c9010010000";
            var bp = bugpr.Where(ps => ps.Id == (Norm.ObjectId)id).FirstOrDefault();

            
            var thisuser = UserSession.Queryable.AsEnumerable().Where(u => u.Email == User.Identity.Name).FirstOrDefault();

            bug.BugSubmitter = thisuser;
            bug.BugProject = bp;
            
            BugSession.Save(bug);

            if (Request.IsAjaxRequest())
            {
                return Json(bug);
            }

            return new RedirectResult("Create");
        }
    }
}
