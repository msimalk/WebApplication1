using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace WebApplication5.Pages.EditUser
{
    public class DeleteModel : PageModel
    {
        private readonly Services.Models.simalContext _context;

        public DeleteModel(Services.Models.simalContext context)
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

            var usertable = await _context.UserTables.FirstOrDefaultAsync(m => m.Ussn == id);

            if (usertable == null)
            {
                return NotFound();
            }
            else 
            {
                UserTable = usertable;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserTables == null)
            {
                return NotFound();
            }
            var usertable = await _context.UserTables.FindAsync(id);

            if (usertable != null)
            {
                UserTable = usertable;
                _context.UserTables.Remove(UserTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
