using System;
using System.Collections.Generic;
using Site.Admin2.ViewModels;

namespace Site.Admin2.ViewModels
{
    public class UsersVM
    {
        public IEnumerable<UserVM> Users { get; set;}
    }
}