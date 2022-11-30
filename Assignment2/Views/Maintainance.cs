using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Views
{
    public class Maintainance
    {
        [BsonId]
        public int maintainanceID { get; set; }
        public DateTime date { get; set; }
        public string? description { get; set; }
        public int itemID { get; set; }
    }
}
