using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace WebApplication5.Pages.EditUser
{
    public class EditModel : PageModel
    {
        private readonly Services.Models.simalContext _context;

        public EditModel(Services.Models.simalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserTable UserTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserTables == null)
            {
                return NotFound();
            }

            var usertable =  await _context.UserTables.FirstOrDefaultAsync(m => m.Ussn == id);
            if (usertable == null)
            {
                return NotFound();
            }
            UserTable = usertable;
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

            _context.Attach(UserTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(UserTable.Ussn))
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

        private bool UserTableExists(int id)
        {
          return (_context.UserTables?.Any(e => e.Ussn == id)).GetValueOrDefault();
        }
    }
}
