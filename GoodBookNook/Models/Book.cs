using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodBookNook.Models
{
    public class Book
    {
        public int BookID { get; set; }
        private List<Author> authors = new List<Author>();
        private List<Review> reviews = new List<Review>();

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        // [DataType(DataType.Date)]  // HTML5 type that will cause a calendar picker to be displayed
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]  // only display formatting, doesn't validate
        [RegularExpression(@"^(1[0-9]|20)\d\d$", ErrorMessage = "Enter a four digit year")]
        public DateTime PubDate { get; set; }

        public List<Author> Authors { get { return authors; } }
        public List<Review> Reviews { get { return reviews; } }
    }
}
