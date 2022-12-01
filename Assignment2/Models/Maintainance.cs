using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Models
{
    public class Maintainance
    {
        [BsonId]
        public string _id { get; set; }
        public int maintainanceID { get; set; }
        public string date { get; set; }
        public string? description { get; set; }
        public int itemID { get; set; }
    }
}
