using ForumAspNetCore3._1.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Repositories
{
    public interface IPostRepository
    {
        Task<Post> GetAsync(int? id);
        Task<PagingList<Post>> GetAllPageFromUserAsync(ClaimsPrincipal User, int page, int itensPerPage);
        Task<PagingList<Post>> GetAllFromPageAsync(int page, int itensPerPage);
        Task AddAsync(ClaimsPrincipal User, Post post);
        Task UpdateAsync(ClaimsPrincipal User, Post post);
        Task DeleteAsync(int id);
        bool PostExists(int id);


    }
}
