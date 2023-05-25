using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using parcial_Horta_Gomez.Data;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Pages.Empleados
{
    public class DeleteModel : PageModel
    {
        private readonly RostrosFelicesContext _context;

        public DeleteModel(RostrosFelicesContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OngetAsync(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.Id == id);

            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                Empleado = empleado;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                Empleado = empleado;
                _context.Empleados.Remove(Empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");

        }
    }
}
