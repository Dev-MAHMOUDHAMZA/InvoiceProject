using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Baranch
    {
        [Key]
        public int BaranchId { get; set; }
        public string BaranchName { get; set; } = string.Empty;
        public string? Adderess { get; set; }

        public int CurrentState { get; set; } = 1;
        public string? CreateUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeleteUserId { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
