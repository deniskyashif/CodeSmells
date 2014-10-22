using System.Data.Entity;

namespace CodeSmells.Web.Posts
{
    using System;
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
<<<<<<< HEAD
            var query = this.Data.Posts.All();
            //    .Select(p => new Post
            //{
            //    Author = this.Data.Users.Find(p.AuthorId).UserName,
            //    Title = p.Title,
            //    Body = p.Body,
            //    Ratings = p.Ratings,
            //    Category = p.Category
            //});
            return query;
=======
            var selectedCategories = from p in this.Data.Posts.All()
                                   group p.PostId by p.Category into g
                                   select new CategoryViewModel(){ CategoryName = g.Key.ToString() ,
                                   PostsCount=g.Count()};           
            return selectedCategories.ToArray();
>>>>>>> 7b54a55775373e95e1469b78b481cc8423928bee
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