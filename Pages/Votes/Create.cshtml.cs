using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VotoSeguro.Data;
using VotoSeguro.Models;

namespace VotoSeguro.Pages.Votes
{
    public class CreateModel : PageModel
    {
        private readonly VotoSeguro.Data.VotoSeguroContext _context;

        public CreateModel(VotoSeguro.Data.VotoSeguroContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VotesRecord VotesRecord { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            VotesRecord.Id = 1;

            _context.VotesRecord.Add(VotesRecord);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
