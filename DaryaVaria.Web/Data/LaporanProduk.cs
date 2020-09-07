using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel;

namespace DaryaVaria.Web.Data.Business
{
    public class LaporanProduk
    {
        [DisplayName("Id Produk")]
        [Key]
        public int IdProduk { get; set; }

        [DisplayName("Nama Produk")]
        public string NamaProduk { get; set; }

        [DisplayName("Tanggal Produksi")]
        [DataType(DataType.Date)]
        public DateTime TanggalProduksi { get; set; }

        [DisplayName("Tanggal Kadaluarsa")]
        [DataType(DataType.Date)]
        public DateTime TanggalKadaluarsa { get; set; }

        [DisplayName("Tanggal Konsumsi")]
        [DataType(DataType.Date)]
        public DateTime TanggalKonsumsi { get; set; }

        [DisplayName("Cara Pemakaian")]
        [MaxLength(500)]
        public string CaraPemakaian { get; set; }

        // inverse navigation and explicit foreign key
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
