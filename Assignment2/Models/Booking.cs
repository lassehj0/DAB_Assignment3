using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Models
{
    public class Booking
    {
        public int bookingID { get; set; }
        public string? note { get; set; }
        public string category { get; set; }
        public string hourInterval { get; set; }
        public int participants { get; set; }
        public string? authentication { get; set; }

        public Facility facility { get; set; }
        public User user { get; set; }
        public List<CPR> CPR { get; set; }
    }
}
