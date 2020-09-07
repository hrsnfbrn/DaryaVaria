using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DaryaVaria.Web.Data;
using DaryaVaria.Web.Data.Business;

namespace DaryaVaria.Web.Pages
{
    public class LaporanProdukModel : PageModel
    {
        private readonly DaryaVaria.Web.Data.ApplicationDbContext _context;

        public LaporanProdukModel(DaryaVaria.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LaporanProduk> LaporanProduk { get;set; }

        public async Task OnGetAsync()
        {
            LaporanProduk = await _context.LaporanProduk
                .Include(l => l.User).ToListAsync();
        }
    }
}
