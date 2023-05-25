using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using parcial_Horta_Gomez.Data;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Pages.Empleados
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

        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Empleados == null || Empleado == null)
            {
                return Page();
            }

            _context.Empleados.Add(Empleado);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
