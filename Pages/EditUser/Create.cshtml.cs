using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Models;

namespace WebApplication5.Pages.EditUser
{
    public class CreateModel : PageModel
    {
        private readonly Services.Models.simalContext _context;

        public CreateModel(Services.Models.simalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserTable UserTable { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UserTables == null || UserTable == null)
            {
                return Page();
            }

            _context.UserTables.Add(UserTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
