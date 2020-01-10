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

        /*
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]  // only display formatting, doesn't validate
        [RegularExpression(@"^(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/(20\d\d)$", ErrorMessage = "Enter a date in mm/dd/yyyy format")]
        */
        public DateTime Birthday { get; set; }
    }
}
