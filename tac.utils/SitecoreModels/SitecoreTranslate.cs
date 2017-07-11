using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAC.Utils.Abstractions;

namespace TAC.Utils.SitecoreModels
{
    public class SitecoreTranslate : ITranslate
    {
        public string Text(string key)
        {
            return Sitecore.Globalization.Translate.Text(key);
        }
    }
}
