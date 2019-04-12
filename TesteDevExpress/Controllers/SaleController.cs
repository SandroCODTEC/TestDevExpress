
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TesteDevExpress.Controllers
{
    public class SaleController : Controller
    {
        public class DataGridController : Controller
        {
            public ActionResult RemoteVirtualScrolling()
            {
                return View();
            }
        }
    }
}