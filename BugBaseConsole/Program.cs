using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugBaseClasses.Infrastructure;
using BugBaseClasses.Model;
using BugBaseClasses.ViewModel;
using Norm;
using AutoMapper;

namespace BugBaseConsole
{

    class Program
    {

        public static void createMap()
        {
            Mapper.CreateMap<BugProject, ProjectViewModel>();
                     
            var sessie = new MongoSession<BugProject>();
            var projects = sessie.Queryable.AsEnumerable();
    
            var theproject = projects.Where(p => p.ProjectName == "Example Project").First();
            var viewmodel = Mapper.Map<BugProject, ProjectViewModel>(theproject);

            System.Console.WriteLine(viewmodel.ProjectName + viewmodel.ProjectOwner.Email + viewmodel.Bugs.FirstOrDefault());
            
        }





        public static void newUser(string username, string mail, string passwd)
        {
            var UserSession = new MongoSession<User>();
            User b = new User();
            b.UserName = username;
            b.Email = mail;
            b.Password = passwd;
            UserSession.Save(b);
        }

        public static void newBug(string mail, string desc, string bugnaam)
        {
            var BugSession = new MongoSession<Bug>();
            var UserSession = new MongoSession<User>();

            var users = UserSession.Queryable.AsEnumerable();
            var thisuser = users.Where(u => u.Email == mail).FirstOrDefault();
            
            Bug myB = new Bug
            {
                Description = desc,
                Name = bugnaam,
                BugSubmitter = thisuser
            };
        }

        public IEnumerable<Bug>allBugs()
        {
            var BugSession = new MongoSession<Bug>();
            return BugSession.Queryable.AsEnumerable();

        }

        public static IEnumerable<User> allUsers()
        {
            var BugSession = new MongoSession<User>();
            return BugSession.Queryable.AsEnumerable();

        }

        public static bool Authenticate(string naam, string password)
        {
            var UserSession = new MongoSession<User>();
            var users = UserSession.Queryable.AsEnumerable();

            if (users.Where(u => u.UserName == naam && u.Password == password).Count() != 0)
            {
                return true;
            }
            else { return false; }
        }

        public static BugProject newBugProject(User user, string projectname, string projectdescription)
        {
            var UserSession = new MongoSession<User>();
            var ProjectSession = new MongoSession<BugProject>();

            var test = Mapper.CreateMap<BugProject,User>();

            
            BugProject p = new BugProject();
            p.ProjectDescription = projectdescription;
            p.ProjectName = projectname;
            p.ProjectOwner = user;

            ProjectSession.Save(p);
            return p;

        }

        public static User findUser(string email)
        {
            var UserSession = new MongoSession<User>();
            var users = UserSession.Queryable.AsEnumerable();
            User user = users.Where(u => u.Email == email).FirstOrDefault();
            return user;

        }

        public static void initializeBugBase()
        {
            newUser("Jacqueline", "info@testdomain.com", "12345");
            // User jp = findUser("info@testdomain.com");

            //NIEUW BUGPROJECT   
             User u = findUser("info@testdomain.com");
             BugProject bp = newBugProject(u, "Example Project", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam");

            //nieuwe bug
             
             Bug bug = new Bug();
             bug.BugProject = bp;
             bug.BugSubmitter = u;
             bug.Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
             bug.Name = "Example name";

             var BugSession = new MongoSession<Bug>();
             BugSession.Save(bug);
                

        }


        static void Main(string[] args)
        {

           //NIEUW BUGPROJECT   
           // User u = findUser("info@testdomain.com");
           // newBugProject(u, "Website for insurancecompany", "Development of a new company website for a insurancecompany with brandnew web 3.0 techniques");

            //NIEUWE USER            
            //newUser("Jacqueline", "info@testdomain.com", "12345");
                       
            /*
            var UserSession = new MongoSession<User>();
            var ProjectSession = new MongoSession<BugProject>();
            var BugSession = new MongoSession<Bug>();

            var gebr = UserSession.Queryable.AsEnumerable();
            var thisuser = gebr.Where(u => u.Email == "info@plop.nl" ).FirstOrDefault();
            var bugpr = ProjectSession.Queryable.AsEnumerable();
            string id = "76a1a60164489cb00c000000";
            var bp = bugpr.Where(ps => ps.Id == (Norm.ObjectId)id).FirstOrDefault();

            Bug bug = new Bug();
            bug.BugProject = bp;
            bug.BugSubmitter = thisuser;
            bug.Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            bug.Name = "Example name";

            BugSession.Save(bug);

            //bug.BugSubmitter = thisuser;


            /*
            p.ProjectDescription = "BugBaseProject zelf";
            p.ProjectName = "BugBase";
            p.ProjectOwner = thisuser;

            ProjectSession.Save(p);
            */
                /*
            var projecten = ProjectSession.Queryable.AsEnumerable();
            foreach (BugProject B in projecten)
            {
                Console.WriteLine(B.ProjectName);
                Console.WriteLine(B.ProjectOwner.UserName);
                Console.WriteLine(B.Id);
            }

            var bugsies = BugSession.Queryable.AsEnumerable();
            var dezebugs = bugsies.Where(p => p.BugProject.Id == (Norm.ObjectId)id);
            Console.WriteLine("Hier de bugsies");
            foreach (Bug b in dezebugs)
            {
                Console.WriteLine(b.BugProject.Id);
                Console.WriteLine(b.BugSubmitter.UserName);
                Console.WriteLine(b.Id);
            }

            */

            //initializeBugBase();


           // createMap();

            //var session = new MongoSession<BugProject>();
            //var buglist = session.Queryable.AsEnumerable<BugProject>();
            var user = new User { Email = "bla@bla.nl", UserName = "jacq" };
            var bugproject = new BugProject { 
                ProjectDescription = "Blackberry app",
                ProjectName = "test", 
                ProjectOwner = user };

            var bug1 = new Bug { 
                Description = "ridicuously slow your app"
            };
            var bug2 = new Bug {
                Description = "take an english lesson please"};

            bugproject.addBug(bug1);
            bugproject.addBug(bug2);

            Mapper.CreateMap<BugProject, BugProjectDTO>();
            BugProjectDTO dto = Mapper.Map<BugProject, BugProjectDTO>(bugproject);
            
            Console.WriteLine(dto.getBugCount);
        }
    }
}
