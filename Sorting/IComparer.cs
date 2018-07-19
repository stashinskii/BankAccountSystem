using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public interface IComparer<T>
    {
        int Compare(T lhs, T rhs);
    }
}
