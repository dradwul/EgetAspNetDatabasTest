using EgetAspNetDatabasTest.Models;
using EgetAspNetDatabasTest.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace EgetAspNetDatabasTest.Pages
{
    public class LoginRegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Credential Credential { get; set; }
        public LoginRegisterViewModel ViewModel { get; set; }


        public LoginRegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Användaren är inloggad, omdirigera till en annan sida
                return RedirectToPage("/AlreadyLoggedIn");
            }

            ViewModel = new LoginRegisterViewModel
            {
                Users = await _context.users.ToListAsync()
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Användaren är redan inloggad, så omdirigera dem bort från inloggningssidan
                return RedirectToPage("/AlreadyLoggedIn");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.users
                        .FirstOrDefaultAsync(u => u.Username == Credential.Username);

            if (user != null && user.Password == Credential.Password)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()), // Använd UserId här
            new Claim(ClaimTypes.Name, user.Username)
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToPage("/LoggedIn");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
}
