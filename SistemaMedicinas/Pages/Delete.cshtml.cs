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
    public class DeleteModel : PageModel
    {
        private readonly SistemaMedicinas.Data.SistemaMedicinasContext _context;

        public DeleteModel(SistemaMedicinas.Data.SistemaMedicinasContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicina = await _context.Medicina.FindAsync(id);

            if (Medicina != null)
            {
                _context.Medicina.Remove(Medicina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
