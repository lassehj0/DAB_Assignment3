using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Views
{
	public class Booking
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; }
		public int bookingID { get; set; }
		public string? note { get; set; }
		public string category { get; set; }
		public string hourInterval { get; set; }
		public int participants { get; set; }
		public string? authentication { get; set; }

		public int facilityID { get; set; }
		public int userID { get; set; }
		public List<CPR> CPR { get; set; }
    }
}
