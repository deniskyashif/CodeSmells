namespace CodeSmells.Web.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using CodeSmells.Models;

    public partial class PostDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var query = this.GetPostById();
            this.CommentsRepeater.DataSource = query.First().Comments.ToList();
            this.Page.DataBind();
        }

        public IQueryable<Post> GetPostById()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("GetPosts.aspx");
            }

            var itemId = int.Parse(Request.Params["id"]);
            var query = this.Data.Posts.All().Where(x => x.PostId == itemId);

            return query;
        }
    }
}