using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstructuer.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Baranch> Baranches { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<InvoiceTemp> InvoiceTemps { get; set; }
        public DbSet<BuyInovice> BuyInovices { get; set; }
        public DbSet<BuyInvoiceItem> BuyInvoiceItems { get; set; }



    }
}
