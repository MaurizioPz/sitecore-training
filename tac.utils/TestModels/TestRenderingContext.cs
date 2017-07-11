using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAC.Utils.Abstractions;

namespace TAC.Utils.TestModels
{
    public class TestRenderingContext : IRenderingContext
    {

        public IItem ContextItem
        {
            get; set;
        }

        public IItem DatsourceOrContext
        {
            get; set;
        }
    }
}
