using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post : BaseModel
    {
        public Post(string title, string description, string linkImage)
        {
            Title = title;
            Description = description;
            LinkImage = linkImage;
        }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [Required]
        public virtual IdentityUser User { get; private set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string LinkImage { get; set; }
    }
}
