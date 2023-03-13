using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public abstract class BaseEntity<T> where T : BaseEntity<T>
    {
        public BaseEntity()
        {
        }

        public object? ToResponse()
        {
            return base.ToString();
        }
    }
}
