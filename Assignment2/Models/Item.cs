using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Models
{
    public class Item
    {
        [BsonId]
        public string _id { get; set; }
        public int itemId { get; set; }
        public string name { get; set; }
        public int facilityID { get; set; }

        public List<Maintainance> Maintainances { get; set; }
    }
}
