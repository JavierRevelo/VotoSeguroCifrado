using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VotoSeguro.Data;
using VotoSeguro.Models;

namespace VotoSeguro.Pages.Votes
{
    public class IndexModel : PageModel
    {
        private readonly VotoSeguro.Data.VotoSeguroContext _context;

        public IndexModel(VotoSeguro.Data.VotoSeguroContext context)
        {
            _context = context;
        }

        public IList<VotesRecord> VotesRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            VotesRecord = await _context.VotesRecord.ToListAsync();
        }
    }
}
