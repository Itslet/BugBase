using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Norm;

namespace BugBaseClasses.Model
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}