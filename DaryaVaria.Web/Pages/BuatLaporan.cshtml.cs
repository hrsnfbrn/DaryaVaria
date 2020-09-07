using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DaryaVaria.Web.Data;
using DaryaVaria.Web.Data.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DaryaVaria.Web.Pages
{
    [Authorize(Roles = "User")]
    public class BuatLaporanModel : PageModel
    {
        private readonly DaryaVaria.Web.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public BuatLaporanModel(DaryaVaria.Web.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);            
            ViewData["UserId"] = user.Id;
            return Page();
        }

        [BindProperty]
        public LaporanProduk LaporanProduk { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LaporanProduk.Add(LaporanProduk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./LaporanProduk");
        }
    }
}
