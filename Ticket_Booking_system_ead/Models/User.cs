/*
* File: User.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the User model for the Ticket Booking System backend.
*/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ticket_Booking_system_Backend_EAD.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

<<<<<<< Updated upstream
=======
        // User's name.
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        // User's password.
>>>>>>> Stashed changes
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        // User's email address.
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        // User's NIC (National Identification Card) number.
        [BsonElement("nic")]
<<<<<<< Updated upstream
        public String Nic { get; set; } = String.Empty;
=======
        public string NIC { get; set; } = string.Empty;
>>>>>>> Stashed changes

        // User's phone number.
        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        // User's type (e.g., admin, regular user).
        [BsonElement("userType")]
        public string UserType { get; set; } = string.Empty;

        // Indicates whether the user's account is active or not.
        [BsonElement("isActive")]
        public bool IsActive { get; set; }
    }
}
