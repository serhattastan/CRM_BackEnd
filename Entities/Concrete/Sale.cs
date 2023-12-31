﻿using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int InstantPrice { get; set; }
        public DateTime Date { get; set; }
        public int SaleStatusId { get; set; }
    }
}
