using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using YahooFinanceApi;

namespace Authentication.Controllers
{
    public class StockTickerListController : ApiController
    {
		[Route("~/api/StockTickerList/{ticker}/{start}/{end}/{period}")]
		[HttpGet]
		public async Task<List<StockPriceModel>> GetStockData(string ticker, string start,
			string end, string period)
		{
			DateTime startDate = DateTime.Now.AddYears(-1);
			DateTime endDate = DateTime.Now;
			var p = Period.Daily;
			if (period.ToLower() == "weekly") p = Period.Weekly;
			else if (period.ToLower() == "monthly") p = Period.Monthly;

			if (start != null && end != null)
			{
				 startDate = DateTime.Parse(start);
				 endDate = DateTime.Parse(end);
			}
			

			var hist = await Yahoo.GetHistoricalAsync(ticker, startDate, endDate, p);

			List<StockPriceModel> models = new List<StockPriceModel>();
			foreach (var r in hist)
			{
				models.Add(new StockPriceModel
				{

					Ticker = ticker,
					Date = r.DateTime.ToString("yyyy-MM-dd"),
					Open = r.Open,
					High = r.High,
					Low = r.Low,
					Close = r.Close,
					AdjustedClose = r.AdjustedClose,
					Volume = r.Volume

				});
			}


			//

			return models;
		}

		
		


	}

	
}
