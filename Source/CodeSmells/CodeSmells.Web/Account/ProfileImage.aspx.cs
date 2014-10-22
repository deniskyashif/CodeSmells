using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeSmells.Web.Account
{
    using Microsoft.AspNet.Identity;

    public partial class ProfileImage : BasePage
    {
        private const int DefaultContentLength = 102400;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void OnUploadBtn_Click(object sender, EventArgs e)
        {
            if (this.UploadImage.HasFile)
            {
                if (this.UploadImage.PostedFile.ContentType == "image/jpeg" ||
                    this.UploadImage.PostedFile.ContentType == "image/gif" ||
                    this.UploadImage.PostedFile.ContentType == "image/png")
                {
                    var user = this.Data.Users.Find(this.User.Identity.GetUserId());

                    var filename = this.User.Identity.Name + Path.GetExtension(this.UploadImage.FileName);
                    this.UploadImage.SaveAs(Server.MapPath("~/Uploads/Images/") + filename);
                    user.ProfileImage = filename;
                    this.Data.SaveChanges();
                }
            }
        }
    }
}