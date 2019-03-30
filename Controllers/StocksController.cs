using StockTicker.Models;
using StockTicker.services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StockTicker.Controllers
{
    public class StocksController : Controller
    {
        // GET: Stocks
        

		[HttpGet]
		public async Task<ActionResult> Index(string searchString,string start,string end)
		{
			StockApiServices services = new StockApiServices();
			IEnumerable<StockPriceModel> views = new List<StockPriceModel>();

			if (!String.IsNullOrEmpty(searchString))
			{
				 views = await services.FindStocks(searchString, start, end);
				
				//Console.WriteLine(views.ToList());
			}

			return View(views.ToList());
		}

		
	}
}