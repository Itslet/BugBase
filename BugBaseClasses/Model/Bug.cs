using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Norm;

namespace BugBaseClasses.Model
{
    public class Bug
    {
        [MongoIdentifier]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User BugSubmitter  { get; set; }
        public BugProject BugProject { get; set; }
    }
}