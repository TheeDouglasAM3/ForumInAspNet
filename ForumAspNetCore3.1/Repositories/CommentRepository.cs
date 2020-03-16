using ForumAspNetCore3._1.Data;
using ForumAspNetCore3._1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllFromPost(int? postId)
        {
            var commentsFromPost = await _context.Comment.Where(c => c.PostId == postId).Include(c => c.User).ToListAsync();
            return commentsFromPost;
        }

        public Task<Comment> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
