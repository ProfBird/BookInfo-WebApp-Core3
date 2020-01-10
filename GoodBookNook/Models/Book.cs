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

        [DataType(DataType.Date)]  // causes default validation and sets the HTML5 data type
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]  // only for display formatting with an HTML helper, doesn't validate
        public DateTime PubDate { get; set; }

        public List<Author> Authors { get { return authors; } }
        public List<Review> Reviews { get { return reviews; } }
    }
}
