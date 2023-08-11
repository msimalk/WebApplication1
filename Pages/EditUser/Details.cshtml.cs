using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.models;

namespace WebApplication5.Pages.EditUser
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication5.Data.WebApplication5Context _context;

        public DetailsModel(WebApplication5.Data.WebApplication5Context context)
        {
            _context = context;
        }

      public Usermodel Usermodel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Usermodel == null)
            {
                return NotFound();
            }

            var usermodel = await _context.Usermodel.FirstOrDefaultAsync(m => m.Id == id);
            if (usermodel == null)
            {
                return NotFound();
            }
            else 
            {
                Usermodel = usermodel;
            }
            return Page();
        }
    }
}
