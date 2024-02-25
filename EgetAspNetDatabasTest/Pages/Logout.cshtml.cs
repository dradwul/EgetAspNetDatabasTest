using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync(); // Anv�nder standardautentiseringsschemat
        return RedirectToPage("/LoginRegister"); // �ndra detta till din inloggningssida eller startsida
    }
}