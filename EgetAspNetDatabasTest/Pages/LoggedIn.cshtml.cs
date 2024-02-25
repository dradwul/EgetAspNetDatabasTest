using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace EgetAspNetDatabasTest.Pages
{
    [Authorize]
    public class LoggedInModel : PageModel
    {
        public void OnGet()
        {
            // Eventuell logik som behövs när sidan laddas
        }
    }
}