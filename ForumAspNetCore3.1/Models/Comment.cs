using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Models
{
    public class Comment : BaseModel
    {
        public Comment()
        {
        }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; private set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public Post Post { get; private set; }

        [Required]
        public string ContentText { get; set; }

    }
}
