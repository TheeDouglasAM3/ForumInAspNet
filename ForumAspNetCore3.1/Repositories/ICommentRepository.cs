using ForumAspNetCore3._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> GetAsync(int? id);
        Task<List<Comment>> GetAllFromPost(int? postId);
    }
}
