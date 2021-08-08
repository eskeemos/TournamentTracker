namespace TrackerLibrary.Models
{
    public class ModelPrize // x
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public int PrizeAmount { get; set; }
        public int PrizePercentage { get; set; }
        public ModelPrize(string placeNumber, string placeName, string prizeAmount, string prizePercentage)
        {
            int.TryParse(placeNumber, out int placeNumberValid);
            int.TryParse(prizeAmount, out int prizeAmountValid);
            int.TryParse(prizePercentage, out int prizePercentageValid);

            PlaceName = placeName;
            PlaceNumber = placeNumberValid;
            PrizeAmount = prizeAmountValid;
            PrizePercentage = prizePercentageValid;
        }
        public ModelPrize() { }
    }
}
