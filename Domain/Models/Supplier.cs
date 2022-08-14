using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Supplier : BaseEntity
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
    }
}
