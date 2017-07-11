using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TAC.Utils.Mvc
{
    public class MvcTag : IDisposable
    {
        public string Tag;
        private readonly TextWriter _writer;
        public MvcTag(string tag, ViewContext viewContext)
        {
            this.Tag = tag;
            _writer = viewContext.Writer;
        }
        public void Dispose()
        {
            this._writer.Write(string.Format("</{0}>", Tag));
        }
    }
}
