using Authentication.Models;
using Authentication.services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Authentication.Controllers
{
    public class HistoricalDataController : Controller
    {
		public ActionResult Index()
		{
			return View();
		}
		// GET: HistoricalData
		[HttpPost]
		public async Task<JsonResult> HistoricalData(string searchString,string start,string end)
		{
			var user_id = User.Identity.GetUserId();
			StockApiServices services = new StockApiServices();
			IEnumerable<StockPriceModel> views = new List<StockPriceModel>();
			if (!String.IsNullOrEmpty(searchString))
			{
				views = await services.FindStocks(searchString,start,end);

			}
			return Json( views.ToList());
		}
	}
}