using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;

namespace BugBaseClasses.Model
{
    public class BugProject
    {
        [MongoIdentifier]
        public ObjectId Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public User ProjectOwner { get; set; }
        private readonly IList<Bug> buglist = new List<Bug>();


        public Bug[] getBugs()
        {
            return buglist.ToArray();
        }

        public void addBug(Bug bug)
        {
            buglist.Add(bug);
        }

        public int getBugCount()
        {
            return buglist.Count();
        }

    }

    public class BugProjectDTO
    {
        public string ProjectDescription { get; set; }
        public string ProjectOwnerEmail { get; set; }
        public int getBugCount { get; set;}
    }
}
