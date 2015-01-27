using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Windsor
{
    public interface IAbstructFactory
    {
        T Create<T>();
        void Release(object value);
    }
}
