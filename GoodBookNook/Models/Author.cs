using System;
using System.ComponentModel.DataAnnotations;

namespace GoodBookNook.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [DataType(DataType.Date)]  // causes default validation and sets the HTML5 data type
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]  // only for display formatting with an HTML helper, doesn't validate
        public DateTime Birthday { get; set; }
    }
}
