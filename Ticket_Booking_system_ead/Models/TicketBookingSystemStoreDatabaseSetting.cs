/*
* File: TicketBookingSystemStoreDatabaseSetting.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the concrete implementation of the ITicketBookingSystemStoreDatabaseSetting interface for database settings in the Ticket Booking System backend.
*/

namespace Ticket_Booking_system_Backend_EAD.Models
{
    public class TicketBookingSystemStoreDatabaseSetting : ITicketBookingSystemStoreDatabaseSetting
    {
        // Name of the collection for storing train data.
        public string TrainCollectionName { get; set; }

        // Name of the collection for storing reservation data.
        public string ReservationCollectionName { get; set; }

        // Name of the collection for storing user data.
        public string UserCollectionName { get; set; }

        // Connection string to the database.
        public string ConnectionString { get; set; }

        // Name of the database.
        public string DatabaseName { get; set; }
    }
}
