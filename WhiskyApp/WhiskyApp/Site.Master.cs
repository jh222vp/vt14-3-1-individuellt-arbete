﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiskyApp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SuccessLiteral.Text = Page.getTempData("Success") as string;

            //Successpanel blir antingen true eller false.
            SuccessPanel.Visible = !String.IsNullOrWhiteSpace(SuccessLiteral.Text);
        }
    }
}