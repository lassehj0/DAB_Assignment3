namespace Assignment2.Views
{
	public class Booking
	{
		public int bookingID { get; set; }
		public string? note { get; set; }
		public string category { get; set; }
		public string hourInterval { get; set; }
		public int participants { get; set; }
		public string? authentication { get; set; }
		public int facilityID { get; set; }
		public int userID { get; set; }
		public List<CPR> CPR { get; set; }

		public Facility facility { get; set; }
		public User user { get; set; }
    }
}
