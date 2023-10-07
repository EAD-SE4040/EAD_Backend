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

        [BsonElement("trainNname")]
        public String TrainNname { get; set; } = String.Empty;

        [BsonElement("schedule")]
        public String Schedule { get; set; } = String.Empty;

        [BsonElement("from")]
        public String From { get; set; } = String.Empty;

        [BsonElement("to")]
        public String To { get; set; } = String.Empty;

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
