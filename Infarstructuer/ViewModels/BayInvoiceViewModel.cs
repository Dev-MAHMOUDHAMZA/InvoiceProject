using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstructuer.ViewModels
{
    public class BayInvoiceViewModel
    {
        public List<Supplier> SupplierList { get; set; } = new List<Supplier>();
        public List<Category> CategoryList { get; set; } = new List<Category>();
        public BuyInovice NewBuyInovice { get; set; } = new BuyInovice();
    }
}
