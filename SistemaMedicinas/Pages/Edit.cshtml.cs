using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaMedicinas.Data;
using SistemaMedicinas.Models;

namespace SistemaMedicinas.Pages
{
    public class EditModel : PageModel
    {
        private readonly SistemaMedicinas.Data.SistemaMedicinasContext _context;

        public EditModel(SistemaMedicinas.Data.SistemaMedicinasContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Medicina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicinaExists(Medicina.ID))
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

        private bool MedicinaExists(int id)
        {
            return _context.Medicina.Any(e => e.ID == id);
        }
    }
}
