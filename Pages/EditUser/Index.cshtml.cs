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
    public class IndexModel : PageModel
    {
        private readonly WebApplication5.Data.WebApplication5Context _context;

        public IndexModel(WebApplication5.Data.WebApplication5Context context)
        {
            _context = context;
        }

        public IList<Usermodel> Usermodel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Usermodel != null)
            {
                Usermodel = await _context.Usermodel.ToListAsync();
            }
        }
    }
}
