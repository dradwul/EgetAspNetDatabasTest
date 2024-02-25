using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using EgetAspNetDatabasTest.Models;
using EgetAspNetDatabasTest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EgetAspNetDatabasTest.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Post> Posts { get; set; }
        
        [BindProperty]
        public string PostData { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? UserId { get; set; } // Används för att filtrera inlägg baserat på UserId

        public DashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (UserId.HasValue)
            {
                Posts = await _context.posts
                    .Where(p => p.UserId == UserId.Value)
                    .ToListAsync();
            }
            else
            {
                Posts = await _context.posts.ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Hämta UserId från claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                // Om vi inte kan hitta ett UserId-claim, hantera felet (t.ex. genom att logga ut användaren)
                return RedirectToPage("/Error");
            }

            var userId = int.Parse(userIdClaim);

            var newPost = new Post
            {
                PostData = this.PostData,
                UserId = userId, // Använd UserId från den inloggade användaren
                                 // Sätt andra nödvändiga egenskaper för ditt Post-objekt här
            };

            _context.posts.Add(newPost);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostUpvoteAsync(int postId)
        {
            var post = await _context.posts.FindAsync(postId);
            if(post != null)
            {
                post.PostUpvotes += 1;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostDownvoteAsync(int postId)
        {
            var post = await _context.posts.FindAsync(postId);
            if (post != null)
            {
                post.PostDownvotes += 1;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}