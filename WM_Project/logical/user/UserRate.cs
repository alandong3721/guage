using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.user
{
    public class UserRate
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string ratetype;
        public string Ratetype
        {
            get { return ratetype; }
            set { ratetype = value; }
        }
    }
}