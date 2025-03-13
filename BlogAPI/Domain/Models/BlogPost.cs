using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BlogPost : BaseModel
    {
        public string Title { get; set; }
       public string Content { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Users  Author { get; set; }

        [ForeignKey("TagId")]
        public Tags Tags { get; set; }
        public int TagId { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Likes> Likes { get; set; }





    }
}
