namespace CodeSmells.Web.Account
{
    using System;
    using System.IO;
    using Microsoft.AspNet.Identity;

    public partial class ProfileImage : BasePage
    {
        private const int DefaultContentLength = 102400;

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void OnUploadBtn_Click(object sender, EventArgs e)
        {
            if(this.UploadImage.HasFile)
            {
                if(this.UploadImage.PostedFile.ContentType == "image/jpeg" ||
                   this.UploadImage.PostedFile.ContentType == "image/gif" ||
                   this.UploadImage.PostedFile.ContentType == "image/png")
                {
                    var user = this.Data.Users.Find(this.User.Identity.GetUserId());

                    var filename = this.User.Identity.Name + Path.GetExtension(this.UploadImage.FileName);
                    this.UploadImage.SaveAs(this.Server.MapPath("~/Uploads/Images/") + filename);
                    user.ProfileImage = filename;
                    this.Data.SaveChanges();
                }
            }
        }
    }
}