using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using parcial_Horta_Gomez.Data;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Pages.Facturas
{
    public class EditModel : PageModel
    {
        private readonly RostrosFelicesContext _context;

        public EditModel(RostrosFelicesContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Factura Factura { get; set; }
        public IList<Cliente> Clientes { get; set; } = default!;
        public IList<Servicio> Servicios { get; set; } = default!;
        public IList<Empleado> Empleados { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FirstOrDefaultAsync(m => m.Id == id);

            if (factura == null)
            {
                return NotFound();
            }

            if (!_context.Clientes.Any() || !_context.Servicios.Any() || !_context.Empleados.Any())
            {
                return NotFound();
            }

            Clientes = _context.Clientes.ToList();
            Servicios = _context.Servicios.ToList();
            Empleados = _context.Empleados.ToList();

            Factura = factura;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

                var servicioSeleccionado = await _context.Servicios
                    .Where(s => s.Name == Factura.NombreServicio)
                    .FirstOrDefaultAsync();

                Factura.price = servicioSeleccionado != null ? servicioSeleccionado.Price : 0;


            _context.Attach(Factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!FacturaExists(Factura.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FacturaExists(int id)
        {
            return (_context.Facturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
