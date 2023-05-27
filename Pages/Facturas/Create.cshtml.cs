using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public IList<Cliente> Clientes { get; set; } = default!;
        public IList<Servicio> Servicios { get; set; } = default!;
        public IList<Empleado> Empleados { get; set; } = default!;

        public IActionResult OnGet()
        {
            if (!_context.Clientes.Any() || !_context.Servicios.Any() || !_context.Empleados.Any())
            {
                return NotFound();
            }

            Clientes = _context.Clientes.ToList();
            Servicios = _context.Servicios.ToList();
            Empleados = _context.Empleados.ToList();

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

            var servicioSeleccionado = await _context.Servicios
            .Where(s => s.Name == Factura.NombreServicio)
            .FirstOrDefaultAsync();

            Factura.price = servicioSeleccionado != null ? servicioSeleccionado.Price : 0;

            _context.Facturas.Add(Factura);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
