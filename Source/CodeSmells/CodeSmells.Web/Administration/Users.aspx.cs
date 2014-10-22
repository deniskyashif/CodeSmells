namespace CodeSmells.Web.Administration
{
    using System;
    using System.Linq;
    using Models;

    public partial class Users : BasePage
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.GridViewUsers.DataBind();
        }

        public IQueryable<User> GridViewUsers_GetData(object sender, EventArgs e)
        {
            var users = this.Data.Users
                .All()
                .Where(u => u.UserName != this.User.Identity.Name)
                .OrderBy(q => q.Id);

            return users;
        }
    }
}