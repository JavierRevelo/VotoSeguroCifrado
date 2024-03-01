using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotoSeguro.Data;
using VotoSeguro.Models;

namespace VotoSeguro.Pages.Votes
{
    public class EditModel : PageModel
    {
        private readonly VotoSeguro.Data.VotoSeguroContext _context;

        public EditModel(VotoSeguro.Data.VotoSeguroContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VotesRecord VotesRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votesrecord =  await _context.VotesRecord.FirstOrDefaultAsync(m => m.Id == id);
            if (votesrecord == null)
            {
                return NotFound();
            }
            VotesRecord = votesrecord;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VotesRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotesRecordExists(VotesRecord.Id))
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

        private bool VotesRecordExists(int id)
        {
            return _context.VotesRecord.Any(e => e.Id == id);
        }
    }
}
