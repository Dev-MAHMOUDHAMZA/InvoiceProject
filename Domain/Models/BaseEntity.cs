using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BaseEntity : RelBaranch
    {
        public int CurrentState { get; set; } = 1;
        public string? CreateUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeleteUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
