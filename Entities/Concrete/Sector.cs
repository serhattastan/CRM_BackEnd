﻿using Core.Entities;

namespace Entities.Concrete
{
    public class Sector : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}