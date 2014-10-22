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
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = manager.GetRoles(userId);

            if (roles.Contains(UserRoleNames.Administrator))
            {
                this.BtnToggleAdminRole.Text = "Remove Admin Rights";
            }
            else if (roles.Contains(UserRoleNames.Banned))
            {
                this.BtnBanUser.Text = "Unban";
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);

            this.TbUserName.Text = user.UserName;
            this.TbEmail.Text = user.Email;
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = manager.GetRoles(userId);

            if (roles.Contains(UserRoleNames.Administrator))
            {
                this.BtnToggleAdminRole.Text = "Remove Admin Rights";
            }
            else if (roles.Contains(UserRoleNames.Banned))
            {
                this.BtnBanUser.Text = "Unban";
            }
        }
         
        protected void BtnToggleAdminRole_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = manager.GetRoles(userId);

            if(roles.Contains(UserRoleNames.Administrator))
            {
                manager.RemoveFromRole(userId, UserRoleNames.Administrator);
            }
            else
            {
                manager.AddToRole(userId, UserRoleNames.Administrator);
            }
            this.Data.SaveChanges();
        }

        protected void BtnBanUser_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = manager.GetRoles(userId);

            if (roles.Contains(UserRoleNames.Banned))
            {
                manager.RemoveFromRole(userId, UserRoleNames.Banned);
            }
            else
            {
                manager.AddToRole(userId, UserRoleNames.Banned);
            }
            this.Data.SaveChanges();
        }

        protected void LinkBtnSaveUser_Click(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);
            user.UserName = this.TbUserName.Text;
            user.Email = this.TbEmail.Text;

            this.Data.SaveChanges();
            Response.Redirect("~/Administration/Users", false);
        }
    }
}