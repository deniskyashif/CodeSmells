namespace CodeSmells.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Post
    {
        public Post()
        {
            this.Ratings = new HashSet<Rating>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public int Rating
        {
            get { return this.Ratings.Sum(r => (int)r.Type); }
            //get { return this.Ratings.Sum(r => (int)r.Type); }
        }
    }
}