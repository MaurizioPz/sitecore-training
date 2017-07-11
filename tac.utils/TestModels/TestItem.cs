using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Collections;
using Sitecore.Links;
using TAC.Utils.Abstractions;

namespace TAC.Utils.TestModels
{
    public class TestItem : IItem
    {
        private readonly IEnumerable<IItem> _children;
        private readonly string _url;
        private readonly Dictionary<string, string> _fields;
        private readonly Guid _id;

      
        public TestItem(string name, string url = null, IEnumerable<IItem> children = null,  Dictionary<string, string> fields= null)
        {
            _children = children ?? new IItem[] { };
            _fields = fields ?? new Dictionary<string, string>() { };
            _url = url;
            _id = Guid.NewGuid();
        }

        public DateTime Created
        {
            get; set;
        }

        public string DisplayName
        {
            get; set;
        }

        public Guid ID
        {
            get
            {
                return _id;
            }
        }

        public string this[string fieldName]
        {
            get
            {
                return _fields[fieldName];
            }

            set
            {
                _fields[fieldName] = value;
            }
        }

        public IEnumerable<IItem> GetChildren()
        {
            return _children;
        }

        public IEnumerable<IItem> GetChildren(ChildListOptions options)
        {
            return _children;
        }

        public string GetUrl()
        {
            return _url;
        }

        public string GetUrl(UrlOptions options)
        {
            return _url;
        }

        public string Render(string fieldname)
        {
            return _fields == null ? null :
                _fields[fieldname]; 
        }

        public string Render(string fieldname, string parameters)
        {
            return Render(fieldname);
        }

        public bool IsAncestorOf(IItem currentItem)
        {
            var testItem = currentItem as TestItem;
            if (testItem == null) return false;
            return this.GetChildren().Contains(testItem) ? true :
                this.GetChildren().Any(c => c.IsAncestorOf(testItem));
        }
    }
}
