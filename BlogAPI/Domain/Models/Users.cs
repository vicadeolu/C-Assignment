using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Users : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Role { get; set; }
        public ICollection<Likes> Likes { get; set; }
        public ICollection<Comments> Comments { get; set; }





    }
}
