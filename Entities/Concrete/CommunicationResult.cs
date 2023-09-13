using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CommunicationResult : IEntity
    {
        public int Id { get; set; }
        public string ResultName { get; set; }
    }
}
