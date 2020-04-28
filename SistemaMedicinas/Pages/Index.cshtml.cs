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
    public class IndexModel : PageModel
    {
        private readonly SistemaMedicinas.Data.SistemaMedicinasContext _context;

        public IndexModel(SistemaMedicinas.Data.SistemaMedicinasContext context)
        {
            _context = context;
        }

        public IList<Medicina> Medicina { get;set; }

        public async Task OnGetAsync()
        {
            Medicina = await _context.Medicina.ToListAsync();
        }
    }
}
