using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BuyInovice: BaseEntity
    {
        [Key]
        public int BuyInvoice { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal afterDiscount { get; set; }

        public List<BuyInvoiceItem> BuyInvoiceItemList { get; set; } = new List<BuyInvoiceItem>();
    }
}
