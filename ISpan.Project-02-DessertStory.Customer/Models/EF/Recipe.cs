using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public int PosterId { get; set; }
        public string? Content { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
