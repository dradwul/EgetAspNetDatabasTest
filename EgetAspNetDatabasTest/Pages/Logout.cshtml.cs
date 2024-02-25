using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync(); // Använder standardautentiseringsschemat
        return RedirectToPage("/LoginRegister"); // Ändra detta till din inloggningssida eller startsida
    }
}