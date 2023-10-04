using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Ticket_Booking_system_Backend_EAD.Models
{
    [BsonIgnoreExtraElements]
    public class Train
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; } = String .Empty;
        [BsonElement("name")]
        public String Name { get; set; } = String.Empty;
        [BsonElement("description")]
        public String Description { get; set; } = String.Empty;

        //[BsonElement("seats_count")]
        //public int seats_count { get; set; } 

        //[BsonElement("to_destination")]
        //public String to_destination { get; set; } = String.Empty;

        //[BsonElement("from_destination")]
        //public String from_destination { get; set; } = String.Empty;

        //[BsonElement("date")]
        //public DateOnly date { get; set; } 

        //[BsonElement("time ")]
        //public TimeOnly time { get; set; } 

    



    }
}
