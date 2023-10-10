/*
* File: ITicketBookingSystemStoreDatabaseSetting.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the interface for database settings in the Ticket Booking System backend.
*/

namespace Ticket_Booking_system_Backend_EAD.Models
{
    public interface ITicketBookingSystemStoreDatabaseSetting
    {
        // Name of the collection for storing train data.
        string TrainCollectionName { get; set; }

        // Name of the collection for storing reservation data.
        string ReservationCollectionName { get; set; }

        // Name of the collection for storing user data.
        string UserCollectionName { get; set; }

        // Connection string to the database.
        string ConnectionString { get; set; }

        // Name of the database.
        string DatabaseName { get; set; }
    }
}
