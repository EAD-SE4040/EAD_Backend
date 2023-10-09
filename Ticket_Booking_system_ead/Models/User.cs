using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Ticket_Booking_system_Backend_EAD.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public String Name { get; set; } = String.Empty;

        [BsonElement("password")]
        public String Password { get; set; } = String.Empty;

        [BsonElement("email")]
        public String Email { get; set; } = String.Empty;

        [BsonElement("nic")]
        public String NIC { get; set; } = String.Empty;

        [BsonElement("phone")]
        public String Phone { get; set; } = String.Empty;

        [BsonElement("userType")]
        public String UserType { get; set; } = String.Empty;

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

    }
}
