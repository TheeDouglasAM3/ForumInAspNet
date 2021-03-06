﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Blog.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPostRepository _postRepository;

        public PostsController(ApplicationDbContext context, IPostRepository postRepository)
        {
            _context = context;
            _postRepository = postRepository;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(await _postRepository.GetAllAsync());
        }

        // GET: Posts/MyPosts
        public async Task<IActionResult> MyPosts()
        {
            return View(await _postRepository.GetAllFromUserAsync(User));
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var post = await _postRepository.GetAsync(id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        // GET: Posts/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Title,Description,LinkImage,Id")] Post post)
        {
            if (ModelState.IsValid)
            {
                await _postRepository.AddAsync(User, post);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postRepository.GetAsync(id);

            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != post.UserId)
                return NotFound();

            if (post == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,LinkImage,Id,UserId")] Post post)
        {
            if (id != post.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _postRepository.UpdateAsync(User, post);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_postRepository.PostExists(post.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postRepository.GetAsync(id);

            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != post.UserId)
                return NotFound();

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _postRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
