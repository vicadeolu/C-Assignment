﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.CommentDTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}
