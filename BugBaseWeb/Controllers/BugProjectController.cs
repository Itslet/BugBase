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
    public class BugProjectController : Controller
    {
        //
        // GET: /BugProject/
        MongoSession<BugProject> session = new MongoSession<BugProject>();

        public ActionResult Index()
        {
            var projects = session.Queryable.AsEnumerable();

            return View(projects);
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}
