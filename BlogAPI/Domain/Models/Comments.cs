using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Models
{
    public class Comments: BaseModel
    {
        public string Content { get; set; }


        [ForeignKey("BlogPostId")]
        public BlogPost Post { get; set; }
        public int PostId { get; set; }


       
        [ForeignKey("UserId")]
        public Users Reader { get; set; }
        public int UserId { get; set; }

    }
}
