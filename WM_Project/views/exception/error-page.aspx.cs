﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views.exception
{
    public partial class error_page : System.Web.UI.Page
    {
        public static string message = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                message = Request.QueryString["message"];
            }
        }
    }
}