using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Models.ViewModels
{
    public class PostAndCommentViewModel
    {
        public PostAndCommentViewModel(Post post)
        {
            Post = post;
        }

        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}
