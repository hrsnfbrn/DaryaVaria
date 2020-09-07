using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DaryaVaria.Web.Data;
using DaryaVaria.Web.Data.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DaryaVaria.Web.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditLaporanModel : PageModel
    {
        private readonly DaryaVaria.Web.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public EditLaporanModel(DaryaVaria.Web.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public LaporanProduk LaporanProduk { get; set; }

        public IList<SelectListItem> PilihanStatus => 
            (new List<string>() { "Open", "Investigation", "Action", "Close" })
            .Select(item => 
            new SelectListItem
            { 
                Value = item, 
                Text = item 
            })
            .ToList();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }            

            LaporanProduk = await _context.LaporanProduk
                .Include(l => l.User).FirstOrDefaultAsync(m => m.IdProduk == id);

            if (LaporanProduk == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LaporanProduk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaporanProdukExists(LaporanProduk.IdProduk))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./LaporanProduk");
        }

        private bool LaporanProdukExists(int id)
        {
            return _context.LaporanProduk.Any(e => e.IdProduk == id);
        }
    }
}
