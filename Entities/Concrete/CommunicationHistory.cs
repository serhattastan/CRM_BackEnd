using Core.Entities;

namespace Entities.Concrete
{
    public class CommunicationHistory : IEntity
    {
        public int Id { get; set; }
        public int CommunicationTypeId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int ResultId { get; set; }
        public int OfferId { get; set; }
    }
}
