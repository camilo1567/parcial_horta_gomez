using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using parcial_Horta_Gomez.Data;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Pages.Servicios
{
    public class CreateModel : PageModel
    {
        private readonly RostrosFelicesContext _context;

        public CreateModel(RostrosFelicesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public Servicio Servicio { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Servicios == null || Servicio == null)
            {
                return Page();
            }

            _context.Servicios.Add(Servicio);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
