using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.models;

namespace WebApplication5.Pages.EditUser
{
    public class EditModel : PageModel
    {
        private readonly WebApplication5.Data.WebApplication5Context _context;

        public EditModel(WebApplication5.Data.WebApplication5Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Usermodel Usermodel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Usermodel == null)
            {
                return NotFound();
            }

            var usermodel =  await _context.Usermodel.FirstOrDefaultAsync(m => m.Id == id);
            if (usermodel == null)
            {
                return NotFound();
            }
            Usermodel = usermodel;
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

            _context.Attach(Usermodel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsermodelExists(Usermodel.Id))
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

        private bool UsermodelExists(int id)
        {
          return (_context.Usermodel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
