using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Models
{
    public class CPR
    {
        public int CPRID { get; set; }
        public string CPRs { get; set; }
        public int bookingID { get; set; }
        public Booking booking { get; set; }
    }
}
