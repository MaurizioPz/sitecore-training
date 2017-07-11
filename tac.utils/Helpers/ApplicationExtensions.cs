using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TAC.Utils.Helpers
{
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Returns the current version of the specified assembly
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static HtmlString ApplicationVersion(this HtmlHelper helper, System.Reflection.Assembly assembly=null)
        {
            if(assembly == null)
            {
                assembly = System.Reflection.Assembly.GetExecutingAssembly();
            }
            var version = assembly.GetName().Version;
            var product = assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), true).FirstOrDefault() as System.Reflection.AssemblyProductAttribute;

            if (version != null && product != null)
            {
                return new HtmlString(string.Format(Statics.AssemblyVersionFormat, version.Major, version.Minor, version.Build, version.Revision));
            }
            else
            {
                return new HtmlString("");
            }

        }
    }
}
