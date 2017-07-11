using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAC.Utils.Abstractions;

namespace TAC.Utils.SitecoreModels
{
    public class SitecorRenderingContext : IRenderingContext
    {
        private readonly RenderingContext _renderingContext;

        public SitecorRenderingContext(RenderingContext renderingContext)
        {
            _renderingContext = renderingContext;
        }
        public IItem ContextItem
        {
            get
            {
                return new SitecoreItem(_renderingContext.ContextItem);
            }
        }

        public IItem DatsourceOrContext
        {
            get
            {
                return new SitecoreItem(_renderingContext.Rendering.Item);
            }
        }
    }
}
