using Authentication.Models;
using Authentication.services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using YahooFinanceApi;

namespace Authentication.Controllers
{
	public class UserViewController : Controller
    {
		ApplicationDbContext db = new ApplicationDbContext();
		// GET: UserView
		[System.Web.Http.HttpGet]
		public  ActionResult Index()
		{
			StockApiServices services = new StockApiServices();
			IEnumerable<StockSummary> views = new List<StockSummary>();

			var user_id = User.Identity.GetUserId();
			var userViews = db.UserStocks.ToList();
			var userId = db.UserStocks.Where(x => x.user_Id == user_id).Select(x => x.user_Id).FirstOrDefault();

			if (userId == null) {
				return RedirectToAction("Index","Home");
			}
			else
			{
				return View(userViews);
			}

			
		}

		[System.Web.Http.HttpPost]
		public async Task<JsonResult> Create(string ticker)
		{
			var user_id = User.Identity.GetUserId();
			StockSummary models = new StockSummary();

			if (!String.IsNullOrEmpty(ticker))
			{
				models = await GetStockQuote(ticker);
			}
			UserStock userStock = new UserStock()
			{
				user_Id = user_id,
				ticker = ticker,
				Change=models.Change,
				ChangePercent=models.ChangePercent
			};

			db.UserStocks.Add(userStock);
			db.SaveChanges();

			return Json(userStock);
		}

		public async Task<StockSummary> GetStockQuote(string ticker)
		{
			var securities = await Yahoo.Symbols(ticker).Fields( "Change", "ChangePercent").Fields( Field.RegularMarketChange, Field.RegularMarketChangePercent).QueryAsync();
			var security = securities[ticker.ToUpper()];
			security.Fields.TryGetValue(ticker, out dynamic key);
			StockSummary models = new StockSummary()
			{
				Ticker = ticker,
				Change = security.RegularMarketChange,
				ChangePercent = security.RegularMarketChangePercent
			};

			return models;
		}

		// GET: UserView/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			UserStock userStock = db.UserStocks.Find(id);
			if (userStock == null)
			{
				return HttpNotFound();
			}
			db.UserStocks.Remove(userStock);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		
	}
}