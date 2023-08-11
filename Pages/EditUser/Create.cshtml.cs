using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication5.Data;
using WebApplication5.models;

namespace WebApplication5.Pages.EditUser
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication5.Data.WebApplication5Context _context;

        public CreateModel(WebApplication5.Data.WebApplication5Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Usermodel Usermodel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Usermodel == null || Usermodel == null)
            {
                return Page();
            }

            _context.Usermodel.Add(Usermodel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
