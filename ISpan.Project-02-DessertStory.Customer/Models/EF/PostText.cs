using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class PostText
    {
        public int PostText1 { get; set; }
        public string? UserId { get; set; }
        public int? PostId { get; set; }
        public string? TContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Post? Post { get; set; }
    }
}
