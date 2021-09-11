using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaNxs.Abstractions;

namespace PruebaNxs.Entities
{
    public abstract class Entity : IEntity
    {
        public int id { get; set; }
      
    }
}
