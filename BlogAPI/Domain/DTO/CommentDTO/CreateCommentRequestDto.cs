﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.CommentDTO
{
    public class CreateCommentRequestDto
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

    }
}
