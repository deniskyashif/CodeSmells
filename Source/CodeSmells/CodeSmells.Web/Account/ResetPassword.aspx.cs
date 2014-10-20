﻿namespace CodeSmells.Web.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Models;

    public partial class ResetPassword : Page
    {
        protected string StatusMessage { get; private set; }

        protected void Reset_Click(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(this.Request);
            if (code != null)
            {
                var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                ApplicationUser user = manager.FindByName(this.Email.Text);
                if (user == null)
                {
                    this.ErrorMessage.Text = "No user found";
                    return;
                }
                IdentityResult result = manager.ResetPassword(user.Id, code, this.Password.Text);
                if (result.Succeeded)
                {
                    this.Response.Redirect("~/Account/ResetPasswordConfirmation");
                    return;
                }
                this.ErrorMessage.Text = result.Errors.FirstOrDefault();
                return;
            }

            this.ErrorMessage.Text = "An error has occurred";
        }
    }
}