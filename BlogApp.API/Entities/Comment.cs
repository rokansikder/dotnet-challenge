using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.API.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentBody { get; set; }
        public int? UserId { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogTopicId { get; set; }
        public virtual User User { get; set; }
        public virtual BlogTopic BlogTopic { get; set; }
    }
}
