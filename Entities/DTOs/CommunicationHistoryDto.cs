using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CommunicationHistoryDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string CommunicationTypeName { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public string ResultName { get; set; }
        public string OfferName { get; set; }
    }
}
