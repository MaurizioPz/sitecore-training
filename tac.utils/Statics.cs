using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC.Utils
{
    public static class Statics
    {
        public static class FieldNames
        {
            public static string System_DisplayName = GetNameForField(FieldIDs.System_DisplayName);
            public static string Class = GetNameForField(FieldIDs.Class);
            public static string ExcludeFromNavigation = GetNameForField(FieldIDs.ExcludeFromNavigation);
            public static string DecorationBanner = GetNameForField(FieldIDs.DecorationBanner);
            public static string ContentHeading = GetNameForField(FieldIDs.ContentHeading);
            public static string ContentIntro = GetNameForField(FieldIDs.ContentIntro);
            public static string ContentBody = GetNameForField(FieldIDs.ContentBody);
            public static string JobImage = GetNameForField(FieldIDs.JobImage);
            public static string JobRelated = GetNameForField(FieldIDs.JobRelated);
            public static string JobHours = GetNameForField(FieldIDs.JobHours);
            public static string JobLocation = GetNameForField(FieldIDs.JobLocation);
            public static string JobType = GetNameForField(FieldIDs.JobType);
            public static string JobTravel = GetNameForField(FieldIDs.JobTravel);
            public static string JobRequirements = GetNameForField(FieldIDs.JobRequirements);
            public static string JobFooter = GetNameForField(FieldIDs.JobFooter);

            private static string GetNameForField(ID fieldID) {
                if (fieldID.ToGuid() != Guid.Empty) {
                    var item = Sitecore.Context.Database.GetItem(fieldID);
                    if (item != null) {
                        return item.Name;
                    }
                }
                return "__Display name";
            }
        }

        public static class FieldIDs
        {
            public static ID System_DisplayName = Sitecore.FieldIDs.DisplayName;
            public static ID Class = new ID("{BA8A2082-696A-4B99-8FD2-413B39A821AF}");
            public static ID ExcludeFromNavigation = new ID("{25D57132-8BA2-4B84-A218-04EF4B7473D1}");
            public static ID DecorationBanner = new ID("{316D090C-0128-4C15-AE3E-0B7AC6423197}");
            public static ID ContentHeading = new ID("{1384A77F-8E0C-40BA-B628-3C5ED330DD86}");
            public static ID ContentIntro = new ID("{AE97D6D0-6BC0-4395-B623-4DBD705C3C18}");
            public static ID ContentBody = new ID("{7790EF56-B7D8-4559-B3B5-5388AB04F639}");
            public static ID JobImage = new ID("{177109FC-DBF4-463B-9BD6-DA70229ECFE8}");
            public static ID JobRelated = new ID("{6D79BF70-A888-46F8-AC0B-EED001DF205F}");
            public static ID JobHours = new ID("{6AB86939-C29F-4035-ABFF-AC0A0D473986}");
            public static ID JobLocation = new ID("{05CF017B-51B6-45A0-A450-4ACB4660197D}");
            public static ID JobType = new ID("{54DFC0B6-B74C-4D09-9AEA-041EC73F7707}");
            public static ID JobTravel = new ID("{CEAD6260-805B-459D-8936-B9894AA60DD6}");
            public static ID JobRequirements = new ID("{022AC3D2-5A86-4CA6-9213-7D612E2B5573}");
            public static ID JobFooter = new ID("{16B2D488-46E1-481D-88B5-CCF8555AD29C}");

        }

        public static class TemplateNames
        {
            public const string ContentPage = "Content Page";
        }

        public static class Parameters
        {
            public const string DisableWebEditing = "disable-web-editing=true";
        }

        public static class RenderingParameters
        {
            public const string Appearance = "Appearance";
            public const string Title = "Title";
        }

        public static class PlaceholderKeys
        {
            public const string HeaderNavigation = "headerNavigation";
            public const string HeaderContent = "headerContent";
            public const string MainContent = "mainContent";
            public const string FooterContent = "footerContent";
        }

        public static class TranslationKeys
        {
            public const string Copyright = "Copyright";
            public const string ReadMore = "Read more";
            public const string Previous = "Previous";
            public const string Next = "Next";
            public const string JobDetails = "JobDetails";
        }

        public static class Tags
        {
            public const string HeaderTag = "header";
        }

        public static class HtmlEncodedChars
        {
            public const string Squot = "&#39;";
            public const string Space = "&#32;";
            public const string Laquo = "&laquo;";
            public const string Raquo = "&raquo;";
        }

        public static class QueryStrings
        {
            public const string Paging = "page";
        }

        public const string DefaultActiveClass = "active";
        public const string DefaultPagerClass = "pagination";
        public const string AssemblyVersionFormat = "{0}.{1}.{2}.{3}";
    }
}
