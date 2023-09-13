using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class SaleStatus : IEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
