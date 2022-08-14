using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BuyInvoiceItem
    {
        [Key]
        public int BuyInvoiceItemId { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public decimal Price { get; set; }
        public decimal Quntity { get; set; }
        public decimal Total { get; set; }

        public int BuyInoviceId { get; set; }
        [ForeignKey("BuyInoviceId")]
        public BuyInovice? BuyInovice { get; set; }
    }
}
