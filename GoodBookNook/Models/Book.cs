using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodBookNook.Models
{
    public class Book
    {
        public int BookID { get; set; }
        private List<Author> authors = new List<Author>();
        private List<Review> reviews = new List<Review>();

        public string Title { get; set; }
        public DateTime PubDate { get; set; }

        // These are "navigational properties", they will
        // cause EF to create FK fields for BookID
        // in Author and Review tables.
        public List<Author> Authors { get { return authors; } }
        public List<Review> Reviews { get { return reviews; } }
    }
}
