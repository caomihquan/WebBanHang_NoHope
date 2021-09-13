using System.Web;
using System.Web.Mvc;

namespace WebBanHang_NoHope
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
