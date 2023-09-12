using Core.Entities;

namespace Entities.Concrete
{
    public class CommunicationType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
