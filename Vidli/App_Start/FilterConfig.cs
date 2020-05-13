using System.Web;
using System.Web.Mvc;

namespace Vidli
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // here we initiate the filters globally
            // initialize the authorize attributes which will not let annonymous users to see pages. 
            filters.Add(new AuthorizeAttribute());
        }
    }
}
