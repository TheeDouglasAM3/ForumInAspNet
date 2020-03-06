using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public Post()
        {
        }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual IdentityUser User { get; private set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string LinkImage { get; set; }
    }
}
