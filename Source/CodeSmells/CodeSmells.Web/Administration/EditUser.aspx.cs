using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeSmells.Web.Administration
{
    public partial class EditUser : BasePage
    {
        private string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = this.Request.QueryString["userId"];

            var user = this.Data.Users.Find(userId);

            if (user.Roles.Count > 0)
            {
                //TODO: resolve roles
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);
            this.TbUserName.Text = user.UserName;
            this.TbEmail.Text = user.Email;
        }

        protected void LinkButtonReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/Users");
        }

        protected void LinkButtonSaveUser_Click(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);
            this.TbUserName.Text = user.UserName;
            this.TbEmail.Text = user.Email;

            this.Data.SaveChanges();
            Response.Redirect("~/Administration/Users", false);
        }

        protected void ButtonBAN_Click(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);
            
            //TODO: Resolve roles; add/remove ban role
        }

        protected void ButtonAdmin_Click(object sender, EventArgs e)
        {
            var user = this.Data.Users.Find(userId);
            //TODO: Resolve roles; add/remove admin role
        }
    }
}