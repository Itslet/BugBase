using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugBaseClasses.Model;

namespace BugBaseClasses.ViewModel
{
    public class BugViewModel
    {
        public List<BugProject> BugProjects { get; private set; }
        public List<Bug> Bugs { get; private set; }
        public List<User> Users { get; private set; } 

        public BugViewModel(List<BugProject> projects, List<Bug> bugs, List<User> users)
        {
            this.BugProjects = projects;
            this.Bugs = bugs;
            this.Users = users;

        }
    }

    public class ProjectViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public User ProjectOwner { get; set; }
        public List<Bug> Bugs { get; private set; }

    }

}
