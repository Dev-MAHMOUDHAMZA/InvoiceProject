using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RelBaranch
    {
        public int BaranchId { get; set; }
        [ForeignKey("BaranchId")]
        public Baranch? Baranch { get; set; }
    }
}

