using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using TAC.Utils.Mvc;

namespace TAC.Utils.Helpers
{
    public static class TagHelper
    {
        /// <summary>
        /// Renders a header tag to the browser
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcTag BeginHeader(this HtmlHelper htmlHelper,
                                   object htmlAttributes)
        {
            return BeginTag(htmlHelper, Statics.Tags.HeaderTag, htmlAttributes);
        }

        /// <summary>
        /// Renders a specific tag to the browser
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="tag"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcTag BeginTag(this HtmlHelper htmlHelper,
                                   string tag,
                                   object htmlAttributes)
        {
            var tagBuilder = new TagBuilder(tag);
            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            //Escape single quotes and spaces         
            htmlHelper.ViewContext.Writer.Write(tagBuilder
                                            .ToString(TagRenderMode.StartTag).Replace(Statics.HtmlEncodedChars.Squot, "\'").Replace(Statics.HtmlEncodedChars.Space, " "));
            return new MvcTag(tag, htmlHelper.ViewContext);
        }
    }
}
