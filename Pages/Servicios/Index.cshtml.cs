using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using parcial_Horta_Gomez.Data;
using parcial_Horta_Gomez.Models;

namespace parcial_Horta_Gomez.Pages.Servicios
{
    public class IndexModel : PageModel
    {
        private readonly RostrosFelicesContext _context;

        public IndexModel(RostrosFelicesContext context)
        {
            _context = context;
        }

        public IList<Servicio> Servicios { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Servicios != null)
            {
                Servicios = await _context.Servicios.ToListAsync();
            }
        }
    }
}
