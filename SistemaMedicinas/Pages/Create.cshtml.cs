using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaMedicinas.Data;
using SistemaMedicinas.Models;

namespace SistemaMedicinas.Pages
{
    public class CreateModel : PageModel
    {
        private readonly SistemaMedicinas.Data.SistemaMedicinasContext _context;

        public CreateModel(SistemaMedicinas.Data.SistemaMedicinasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Medicina Medicina { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Medicina.Add(Medicina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}