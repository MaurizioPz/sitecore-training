using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace TAC.Utils.Mvc
{
    public class EditFrameRendering : IDisposable
    {
        private readonly EditFrame _editFrame;
        private readonly HtmlTextWriter _htmlWriter;

        public EditFrameRendering(TextWriter writer, string dataSource, string buttons)
        {
            this._htmlWriter = new HtmlTextWriter(writer);
            this._editFrame = new EditFrame { DataSource = dataSource, Buttons = buttons };
            this._editFrame.RenderFirstPart(this._htmlWriter);
        }


        public void Dispose()
        {
            this._editFrame.RenderLastPart(this._htmlWriter);
            this._htmlWriter.Dispose();
        }
    }
}
