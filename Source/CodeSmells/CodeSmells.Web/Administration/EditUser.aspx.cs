using CodeSmells.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CodeSmells.Web.Administration
{
    public partial class EditUser : BasePage
    {
        private string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = this.Request.QueryString["userId"];

            var user = this.Data.Users.Find(userId);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);

            this.TbUserName.Text = user.UserName;
            this.TbEmail.Text = user.Email;
        }
         
        protected void BtnToggleAdminRole_Click(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);
        }

        protected void BtnBanUser_Click(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);
        }

        protected void LinkBtnSaveUser_Click(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);
            this.TbUserName.Text = user.UserName;
            this.TbEmail.Text = user.Email;

            this.Data.SaveChanges();
            Response.Redirect("~/Administration/Users", false);
        }
    }
}