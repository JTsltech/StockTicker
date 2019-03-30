using Authentication.Models;
using Authentication.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using YahooFinanceApi;

namespace Authentication.Controllers
{
	public class HomeController : Controller
    {
		ApplicationDbContext db = new ApplicationDbContext();

		public ActionResult Index()
		{
			ViewBag.stock = db.StockLists.ToList();
			return View();
		}

		[HttpGet]
		public async Task<ActionResult> GetDataValues(string searchString)
		{
			var user_id = User.Identity.GetUserId();

			ViewBag.searchString = searchString;

			ViewBag.Id = user_id;
			StockSummary models = new StockSummary();

			if (!String.IsNullOrEmpty(searchString))
			{
				models = await GetStockQuote(searchString);
			}

			ViewBag.stock = db.StockLists.ToList();

			return View("Index");
		}

		[HttpPost]
		public async Task<JsonResult> GetData(string searchString)
		{
			var user_id = User.Identity.GetUserId();

			ViewBag.searchString = searchString;

			ViewBag.Id = user_id;
			StockSummary models = new StockSummary();

			if (!String.IsNullOrEmpty(searchString))
			{
				models = await GetStockQuote(searchString);
			}

			return Json( models);
		}


		public async Task<StockSummary> GetStockQuote(string ticker)
		{
			var securities = await Yahoo.Symbols(ticker).Fields(Field.LongName, Field.RegularMarketPrice,Field.RegularMarketChange,Field.RegularMarketChangePercent, Field.FiftyTwoWeekHigh, Field.FiftyTwoWeekLow, Field.RegularMarketDayLow, Field.RegularMarketDayHigh,Field.RegularMarketOpen,Field.RegularMarketPreviousClose,Field.RegularMarketVolume,Field.Bid,Field.BidSize,Field.Ask,Field.AskSize,Field.EarningsTimestamp,Field.EpsForward,Field.FinancialCurrency,Field.MarketCap).QueryAsync();
			var security = securities[ticker.ToUpper()];
			security.Fields.TryGetValue(ticker, out dynamic key);
			StockSummary models = new StockSummary()
			{
				Ticker = ticker,
				Name = security.LongName,
				Change = security.RegularMarketChange,
				ChangePercent = security.RegularMarketChangePercent,
				weekHigh = security.FiftyTwoWeekHigh,
				weekLow = security.FiftyTwoWeekLow,
				dayHigh =security.RegularMarketDayHigh,
				dayLow=security.RegularMarketDayLow,
				Open=Convert.ToDecimal(security.RegularMarketOpen),
				Close= Convert.ToDecimal(security.RegularMarketPreviousClose),
				Bid=security.Bid,
				Ask=security.Ask,
				BidSize=security.BidSize,
				AskSize=security.AskSize,
				market=security.MarketCap,
				Currency=security.Currency,
				Volume=security.RegularMarketVolume

			};

			return models;
		}


	}
}