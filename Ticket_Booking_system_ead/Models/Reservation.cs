/*
* File: Reservation.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the Reservation model for the Ticket Booking System backend.
*/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ticket_Booking_system_Backend_EAD.Models
{
    [BsonIgnoreExtraElements]
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("userID")]
        public string UserID { get; set; } = string.Empty;

        [BsonElement("trainID")]
        public string TrainID { get; set; } = string.Empty;

        [BsonElement("reservationDate")]
        public String ReservationDate { get; set; } = String.Empty;

        // Number of seats reserved.
        [BsonElement("noOfSeats")]
        public int NoOfSeats { get; set; }

        // Reservation status (e.g., confirmed or not).
        [BsonElement("status")]
        public String Status { get; set; } = String.Empty;
    }
}
