using System.Web;
using System.Web.Mvc;

namespace Above_All_Beauty_Pageant
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
