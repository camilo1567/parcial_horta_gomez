using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using parcial_Horta_Gomez.Data;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly RostrosFelicesContext _context;

        public DeleteModel(RostrosFelicesContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OngetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                Cliente = cliente;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                Cliente = cliente;
                _context.Clientes.Remove(Cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");

        }
    }
}
