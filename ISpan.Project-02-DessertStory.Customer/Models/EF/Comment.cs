using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int PosterId { get; set; }
        public string? Content { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
