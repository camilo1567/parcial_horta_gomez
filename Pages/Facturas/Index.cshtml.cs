using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using parcial_Horta_Gomez.Data;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Pages.Facturas
{
    public class IndexModel : PageModel
    {
        private readonly RostrosFelicesContext _context;

        public IndexModel(RostrosFelicesContext context)
        {
            _context = context;
        }

        public IList<Factura> Facturas { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Facturas != null)
            {
                Facturas = await _context.Facturas.ToListAsync();
            }
        }
    }
}
