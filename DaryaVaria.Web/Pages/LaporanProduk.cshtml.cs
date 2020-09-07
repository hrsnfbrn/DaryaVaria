using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DaryaVaria.Web.Data;
using DaryaVaria.Web.Data.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DaryaVaria.Web.Pages
{
    [Authorize]
    public class LaporanProdukModel : PageModel
    {
        private readonly DaryaVaria.Web.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public LaporanProdukModel(DaryaVaria.Web.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<LaporanProduk> LaporanProduk { get;set; }

        public IList<string> Roles { get; set; }

        public async Task OnGetAsync()
        {
            LaporanProduk = await _context.LaporanProduk
                .Include(l => l.User).ToListAsync();

            var user = await _userManager.GetUserAsync(HttpContext.User);            
            Roles = await _userManager.GetRolesAsync(user);
        }
    }
}
