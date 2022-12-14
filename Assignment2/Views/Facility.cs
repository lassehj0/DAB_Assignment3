using NetTopologySuite.Geometries;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Views
{
    public class Facility
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int facilityID { get; set; }
        public int maxOccupants { get; set; }
        public bool reservable { get; set; }
        public string? description { get; set; }
        public string? utilities { get; set; }
        public double[] coordinates { get; set; }
        public string kind { get; set; }
        public string facilityName { get; set; }

        public List<Item> items { get; set; }
        public List<Booking> bookings { get; set; }
    }
}
