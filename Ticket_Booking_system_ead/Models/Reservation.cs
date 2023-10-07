using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Ticket_Booking_system_Backend_EAD.Models
{
    [BsonIgnoreExtraElements]
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; } = String.Empty;

        [BsonElement("userID")]
        public String UserID { get; set; } = String.Empty;

        [BsonElement("trainID")]
        public String TrainID { get; set; } = String.Empty;

        [BsonElement("reservationDate")]
        public String ReservationDate { get; set; } = String.Empty;

        [BsonElement("status")]
        public String Status { get; set; } = String.Empty;
    }
}
