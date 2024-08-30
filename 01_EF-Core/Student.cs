using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_EF_Core
{
    public class Students
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = null!;
        public virtual int Age { get; set; }
        public virtual int Grade { get; set; }

        public override string ToString()
        {
            return $"[{Id}], [{Name}], [{Age}], [{Grade}]";
        }
    }
}
