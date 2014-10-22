using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace CodeSmells.Web.Posts
{
    using System;
    using System.Web.UI;

    using CodeSmells.Models;

    public partial class CreatePost : BasePage
    {
        public void AddPost()
        {
            var post = new Post();
            post.AuthorId = this.User.Identity.GetUserId();
            post.Category = (Category)Enum.Parse(typeof(Category), this.CategoryDropDownList.SelectedValue);
            TryUpdateModel(post);
            if (ModelState.IsValid)
            {
                this.Data.Posts.Add(post);
                this.Data.SaveChanges();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/"); //change to posts
        }
        protected void AddPostForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("GetPosts.aspx"); //chage to posts
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CategoryDropDownList.DataSource = Enumeration.GetAll<Category>();
                this.CategoryDropDownList.DataTextField = "Value";
                this.CategoryDropDownList.DataValueField = "Key";
                this.CategoryDropDownList.DataBind();
            }
        }
    }
}