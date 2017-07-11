using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC.Utils.Abstractions
{
    public interface IItem
    {
        string Render(string fieldname);
        string Render(string fieldname, string parameters);
        string GetUrl();
        string GetUrl(UrlOptions options);
        DateTime Created { get; }
        string DisplayName { get; }
        Guid ID { get; }
        IEnumerable<IItem> GetChildren();
        IEnumerable<IItem> GetChildren(Sitecore.Collections.ChildListOptions options);
        bool IsAncestorOf(IItem currentItem);
        string this[string fieldName] { get; set; }
    }
}
