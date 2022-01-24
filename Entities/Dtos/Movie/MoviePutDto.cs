using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class MoviePutDto
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsRenting { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime? FinishRentTime { get; set; }
    }
}
