using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SaleDetailDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int InstantPrice { get; set; }
        public DateTime Date { get; set; }
        public string SaleStatusName { get; set; }
    }
}
