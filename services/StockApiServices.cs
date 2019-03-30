using Authentication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Authentication.services
{
	public class StockApiServices
	{
		private const string Url = "http://localhost:53590/api/StockTickerList";
		private HttpClient _client = new HttpClient();

		public async Task<IEnumerable<StockPriceModel>> FindStocks(string ticker,string start,string end)
		{
			if (start == "" && end == "")
			{
				start = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
				end = DateTime.Now.ToString("yyyy-MM-dd");

			}
			

			var url = Url + "/" + ticker+"/"+ start+"/"+end+"/"+"daily";
			var response = await _client.GetAsync(url);

			if (response.StatusCode == HttpStatusCode.NotFound)
				return Enumerable.Empty<StockPriceModel>();

			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<StockPriceModel>>(content);
		}
	}
}