using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment2.Views
{
    public class Item
    {
        [BsonId]
        public int itemId { get; set; }
        public string name { get; set; }
        public int facilityID { get; set; }

        public List<Maintainance> maintainances { get; set; }
    }
}
