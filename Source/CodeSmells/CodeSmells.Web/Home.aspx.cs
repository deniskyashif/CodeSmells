namespace CodeSmells.Web
{
    using CodeSmells.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LatestPosts.DataSource = this.GetLatestPosts();
            this.LatestPosts.DataBind();
        }

        public IEnumerable<Post> GetLatestPosts()
        {
            var result = this.Data.Posts
                                  .All()
                                  .OrderByDescending(p => p.DateCreated)
                                  .Take(10)
                                  .ToList();

            return result;
        }
    }
}