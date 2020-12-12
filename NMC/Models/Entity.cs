using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }

        public override string ToString()
        {
            return $"Entity({Id})";
        }
    }
}
