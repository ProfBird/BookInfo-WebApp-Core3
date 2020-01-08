using System.Collections.Generic;

namespace GoodBookNook.Models
{
    public class User
    {
        private List<Review> reviews = new List<Review>();
        private List<Comment> comments = new List<Comment>();

        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // These are "navigational properties" that will cause
        // EF to generate FK fields for UserID in the Review and Comment tables.
        public List<Review> Reviews {get { return reviews; } }
        public List<Comment> Comments { get { return comments; } }

    }
}
