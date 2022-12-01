using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Views
{
    public class Maintainance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int maintainanceID { get; set; }
        public string date { get; set; }
        public string? description { get; set; }
        public int itemID { get; set; }
    }
}
