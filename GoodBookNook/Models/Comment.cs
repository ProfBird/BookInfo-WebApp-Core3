using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodBookNook.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }


        // EF will generate a FK field, UserNameUserID, in the Comment table.
        public User UserName { get; set; }

        // EF will generate a FK field, UserReviewReviewID, in the Comment table.
        public Review UserReview { get; set; }
    }
}
