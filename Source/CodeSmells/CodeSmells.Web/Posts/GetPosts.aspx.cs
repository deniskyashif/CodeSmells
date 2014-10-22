namespace CodeSmells.Web.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using CodeSmells.Models;
    using CodeSmells.Web.Posts.ViewModels;

    public partial class GetPosts : BasePage
    {        
        public Post[] GetAllPosts()
        {            
            var selectedPosts =  this.Data.Posts.All();
            return selectedPosts.ToArray();
        }

        public CategoryViewModel[] GetAllCategories()
        {
            var selectedCategories = from p in this.Data.Posts.All()
                                   group p.PostId by p.Category into g
                                   select new CategoryViewModel(){ CategoryName = g.Key.ToString() ,
                                   PostsCount=g.Count()};           
            return selectedCategories.ToArray();
        }

        //private void ExtractCategories

        public CategoryViewModel[] Categories;

        public Post[] Posts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Posts=this.GetAllPosts();            
            this.Categories = this.GetAllCategories();
        }
    }
}