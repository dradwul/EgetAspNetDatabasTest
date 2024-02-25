using EgetAspNetDatabasTest.Data;
using EgetAspNetDatabasTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EgetAspNetDatabasTest.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Notera användningen av 'async' och att returtypen matchar interfacet exakt.
        public async Task<List<Post>> GetPostsAsync()
        {
            return await _context.posts.ToListAsync();
        }

        //NYTT:
        public async Task AddPostAsync(Post newPost)
        {
            _context.posts.Add(newPost);
            await _context.SaveChangesAsync();
        }

    }
}