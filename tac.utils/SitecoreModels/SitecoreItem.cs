using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Collections;
using TAC.Utils.Abstractions;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace TAC.Utils.SitecoreModels
{
    public class SitecoreItem : IItem
    {
        private readonly Item _item;
        public SitecoreItem(Item item)
        {
            _item = item;
        }
        public DateTime Created
        {
            get
            {
                return _item.Created;
            }
        }

        public string DisplayName
        {
            get
            {
                return _item.DisplayName;
            }
        }

        public Guid ID
        {
            get
            {
                return _item.ID.ToGuid();
            }
        }

        public string this[string fieldName]
        {
            get
            {
                return _item[fieldName];
            }

            set
            {
                _item[fieldName] = value;
            }
        }

        public string GetUrl()
        {
            return LinkManager.GetItemUrl(_item, UrlOptions.DefaultOptions);
        }

        public string GetUrl(Sitecore.Links.UrlOptions options)
        {
            return LinkManager.GetItemUrl(_item, options);
        }

        public IEnumerable<IItem> GetChildren()
        {
            return GetChildren(ChildListOptions.None);
        }

        public IEnumerable<IItem> GetChildren(ChildListOptions options)
        {
            return _item.GetChildren(options).Select(i => new SitecoreItem(i));
        }

        public string Render(string fieldname)
        {
            return FieldRenderer.Render(_item, fieldname);
        }

        public string Render(string fieldname, string parameters)
        {
            return FieldRenderer.Render(_item, fieldname, parameters);
        }

        public bool IsAncestorOf(IItem currentItem)
        {
            var sitecoreItem = currentItem as SitecoreItem;
            if (sitecoreItem != null)
            { return _item.Axes.IsAncestorOf(sitecoreItem._item); }
            return false;
        }


    }
}
