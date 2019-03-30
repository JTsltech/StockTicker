using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Models
{
	[JsonObject]
	public class StockPriceModel
	{
		public string userId { get; set; }
		 public string Ticker { get; set; }
        public string Date { get; set; }
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? Close { get; set; }
        public decimal? AdjustedClose { get; set; }
        public decimal? Volume { get; set; }
		public double? Change { get; set; }
		public double ChangePercent { get; set; }
		public double? weekHigh { get; set; }
		public double? weekLow { get; set; }
		public string Name { get; set; }
	}

	public class UserStock
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string ticker { get; set; }

		public string user_Id { get; set; }

		[ForeignKey("user_Id")]
		public virtual ApplicationUser AspNetUser { get; set; }

		public double? Change { get; set; }
		public double ChangePercent { get; set; }
	}

	public class StockSummary : StockPriceModel
	{
		public long? DateString { get; set; }
		public long? AverageDailyVolume { get; set; }
		public long? AskSize { get; set; }
		public long? BidSize { get; set; }
		public double? Bid { get; set; }
		public double? Ask { get; set; }
		public double?dayLow{get;set;}
		public double? dayHigh { get; set; }
		public double? EPS { get; set; }
		public string Currency { get; set; }
		public double? market { get; set; }
	}

	public class StockList
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string ticker { get; set; }
		public string name { get; set; }
	}
}