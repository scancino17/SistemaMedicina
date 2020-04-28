using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaMedicinas.Data;
using SistemaMedicinas.Models;

namespace SistemaMedicinas.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly SistemaMedicinas.Data.SistemaMedicinasContext _context;

        public DetailsModel(SistemaMedicinas.Data.SistemaMedicinasContext context)
        {
            _context = context;
        }

        public Medicina Medicina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicina = await _context.Medicina.FirstOrDefaultAsync(m => m.ID == id);

            if (Medicina == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
