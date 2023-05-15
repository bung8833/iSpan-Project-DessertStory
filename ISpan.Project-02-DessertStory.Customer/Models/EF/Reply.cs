using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Reply
    {
        public int ReplyId { get; set; }
        public int? PostId { get; set; }
        public string? UserId { get; set; }
        public string? TContent { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Post? Post { get; set; }
    }
}
