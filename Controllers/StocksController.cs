using Authentication.Models;
using Authentication.services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using YahooFinanceApi;

namespace Authentication.Controllers
{
	public class StocksController : Controller
    {
		public ActionResult Stocks()
		{
			return View();
		}


		// GET: Stocks
		[HttpPost]
		public async Task<ActionResult> GetData(string searchString, string start, string end)
		{
			var user_id = User.Identity.GetUserId();

			ViewBag.searchString = searchString;

			ViewBag.Id = user_id;
			StockPriceModel models = new StockPriceModel();

			if (!String.IsNullOrEmpty(searchString))
			{
				models = await GetStockQuote(searchString);
			}

			return View("Stocks", models);
		}


		public async Task<StockPriceModel> GetStockQuote(string ticker)
		{
			var securities = await Yahoo.Symbols(ticker).Fields("Name", "Price", "weekHigh", "weekLow", "Change", "ChangePercent").Fields(Field.LongName, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh, Field.FiftyTwoWeekLow, Field.RegularMarketChange, Field.RegularMarketChangePercent).QueryAsync();
			var security = securities[ticker.ToUpper()];
			security.Fields.TryGetValue(ticker, out dynamic key);
			StockPriceModel models = new StockPriceModel()
			{
				Ticker = ticker,
				Name = security.LongName,
				Change = security.RegularMarketChange,
				ChangePercent = security.RegularMarketChangePercent,
				weekHigh = security.FiftyTwoWeekHigh,
				weekLow = security.FiftyTwoWeekLow
			};

			return models;
		}
	}
}