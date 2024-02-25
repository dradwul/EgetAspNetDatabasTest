using EgetAspNetDatabasTest.Models;

namespace EgetAspNetDatabasTest.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();
    }
}
