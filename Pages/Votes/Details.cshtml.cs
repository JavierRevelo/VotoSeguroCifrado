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
    public class DetailsModel : PageModel
    {
        private readonly VotoSeguro.Data.VotoSeguroContext _context;

        public DetailsModel(VotoSeguro.Data.VotoSeguroContext context)
        {
            _context = context;
        }

        public VotesRecord VotesRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votesrecord = await _context.VotesRecord.FirstOrDefaultAsync(m => m.Id == id);
            if (votesrecord == null)
            {
                return NotFound();
            }
            else
            {
                VotesRecord = votesrecord;
            }
            return Page();
        }
    }
}
