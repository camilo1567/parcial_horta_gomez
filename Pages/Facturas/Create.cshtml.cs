using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using parcial_Horta_Gomez.Data;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Pages.Facturas
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

        public Factura Factura { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Facturas == null || Factura == null)
            {
                return Page();
            }

            _context.Facturas.Add(Factura);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
