using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Movie : BaseEntity
    {
        public string MovieName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsRenting { get; set; }
        public DateTime? FinishRentTime { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
