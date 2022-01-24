using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Vms
{
    public class MovieVm
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsRenting { get; set; }
        public string CategoryName { get; set; }
        public DateTime? FinishRentTime { get; set; }
    }
}
