using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Models.ViewModels
{
    public class PostAndCommentViewModel
    {
        public PostAndCommentViewModel(Post post, List<Comment> comments)
        {
            Post = post;
            Comments = comments;
        }

        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment CommentToSend { get; set; }
    }
}
