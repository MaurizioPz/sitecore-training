using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC.Utils.Abstractions
{
    public interface IRenderingContext
    {
        IItem DatsourceOrContext { get; }
        IItem ContextItem { get; }
    }
}
