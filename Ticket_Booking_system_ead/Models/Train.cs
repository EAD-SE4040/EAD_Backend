/*
* File: Train.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the Train model for the Ticket Booking System backend.
*/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ticket_Booking_system_Backend_EAD.Models
{
    [BsonIgnoreExtraElements]
    public class Train
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        // Name of the train.
        [BsonElement("trainName")]
        public string TrainName { get; set; } = string.Empty;

        // Scheduled departure date and time.
        [BsonElement("scheduleDateTime")]
        public DateTime ScheduleDateTime { get; set; }

        // Total number of seats available on the train.
        [BsonElement("seatsCount")]
        public int SeatsCount { get; set; }

        // Departure location.
        [BsonElement("from")]
        public string From { get; set; } = string.Empty;

        // Destination location.
        [BsonElement("to")]
        public string To { get; set; } = string.Empty;
    }
}
