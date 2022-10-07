namespace CryptoChecker.Models
{
    public class Currency
    {
        public string Id { get; set; }
        public int? Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double? Supply { get; set; }
        public double? MasSupply { get; set; }
        public double? MarketCapUsd { get; set; }
        public double? VolumeUsd24Hr { get; set; }
        public double? PriceUsd { get; set; }
        public double? ChangePercent24Hr { get; set; }
        public double? Vwap24Hr { get; set; }
        public string explorer { get; set; }
    }
}
