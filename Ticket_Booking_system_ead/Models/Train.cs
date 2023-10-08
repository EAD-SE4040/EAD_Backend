using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Ticket_Booking_system_Backend_EAD.Models
{
    [BsonIgnoreExtraElements]
    public class Train
    {

        [BsonId]
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("trainName")] 
        public string TrainName { get; set; } = string.Empty;


        [BsonElement("scheduleDateTime")] 
        public DateTime ScheduleDateTime { get; set; }

        [BsonElement("seatsCount")] 
        public int SeatsCount { get; set; }

        [BsonElement("from")]
        public string From { get; set; } = string.Empty;

        [BsonElement("to")]
        public string To { get; set; } = string.Empty;







    }
}
