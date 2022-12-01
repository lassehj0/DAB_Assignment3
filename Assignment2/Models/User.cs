using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int userID { get; set; }
        public string category { get; set; }
        public int? CVR { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public string name { get; set; }

        public List<Booking> bookings { get; set; }
    }
}
