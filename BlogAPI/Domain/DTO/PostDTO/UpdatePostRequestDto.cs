using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.PostDTO
{
    public class UpdatePostRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int TagId { get; set; }


    }
}
