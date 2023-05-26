using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using parcial_Horta_Gomez.Models;
using parcial_Horta_Gomez.Data;
using System.Security.Claims;

namespace parcial_Horta_Gomez.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]

        public User User { get; set; }

        private readonly RostrosFelicesContext _context;

        public LoginModel(RostrosFelicesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var findUser = await _context.Users
                .Where(x => x.Name == User.Name && x.Email == User.Email && x.Password == User.Password)
                .FirstOrDefaultAsync();

            if (findUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, User.Name),
                    new Claim(ClaimTypes.Email, User.Email),
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                RedirectToPage("../Index");
            }
            else
            {
                Redirect("/Login");
            }

            return Page();
        }

    }
}
