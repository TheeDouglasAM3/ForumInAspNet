using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ForumAspNetCore3._1.Data;
using ForumAspNetCore3._1.Models;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace ForumAspNetCore3._1.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClaimsPrincipal User, Post post)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            post.UserId = userId;
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> GetAsync(int? id)
        {
            var post = await _context.Post
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            return post;
        }

        public async Task<PagingList<Post>> GetAllFromPageAsync(int page = 1, int itensPerPage = 10)
        {
            var query = _context.Post.AsNoTracking().Include(p => p.User).OrderBy(p => p.CreatedAt);
            var postPaginate = await PagingList.CreateAsync(query, itensPerPage, page);

            return postPaginate;
        }

        public async Task UpdateAsync(ClaimsPrincipal User, Post post)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == post.UserId)
            {
                _context.Update(post);
                await _context.SaveChangesAsync();
            }
        }

        public bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }

        public async Task<PagingList<Post>> GetAllPageFromUserAsync(ClaimsPrincipal User, int page = 1, int itensPerPage = 10)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var query = _context.Post
                .AsNoTracking()
                .Include(p => p.User)
                .Where(p => p.UserId == userId)
                .OrderBy(p => p.CreatedAt);

            var postPaginate = await PagingList.CreateAsync(query, itensPerPage, page);

            return postPaginate;
        }
    }
}
