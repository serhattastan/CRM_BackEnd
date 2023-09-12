using Core.Entities;

namespace Entities.Concrete
{
    public class SaleStatus : IEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
