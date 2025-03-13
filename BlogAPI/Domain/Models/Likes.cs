using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Likes: BaseModel
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
       
        public Users Readers { get; set; }
        public int PostId { get; set; }

        [ForeignKey("BlogPostId")]
        public BlogPost Post { get; set; }


    }
}
