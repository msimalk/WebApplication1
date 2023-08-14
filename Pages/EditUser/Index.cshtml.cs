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
    public class IndexModel : PageModel
    {
        private readonly Services.Models.simalContext _context;

        public IndexModel(Services.Models.simalContext context)
        {
            _context = context;
        }

        public IList<UserTable> UserTable { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserTables != null)
            {
                UserTable = await _context.UserTables.ToListAsync();
            }
        }
    }
}
