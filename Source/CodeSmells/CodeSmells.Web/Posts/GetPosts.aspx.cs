namespace CodeSmells.Web.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using CodeSmells.Models;

    public partial class GetPosts : BasePage
    {        
        public IQueryable<Post> GetAllPosts()
        {            
            var query =  this.Data.Posts.All();
            return query;
        }

        //private void ExtractCategories

        public Post test;

        public string[] collection=new string[]{"a","b","c","d"};

        protected void Page_Load(object sender, EventArgs e)
        {
            Post[] posts=this.GetAllPosts().ToArray();
            test = posts[0];
        }
    }
}