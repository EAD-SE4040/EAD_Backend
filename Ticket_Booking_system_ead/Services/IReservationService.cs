/*
* File: IReservationService.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the interface for the Reservation Service in the Ticket Booking System backend.
*/

using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public interface IReservationService
    {
        // Retrieves a list of all reservations.
        List<Reservation> GetReservations();

        // Retrieves a reservation by its ID.
        Reservation GetReservation(String id);

        // Creates a new reservation.
        Reservation CreateReservation(Reservation reservation);

        // Updates an existing reservation by its ID.
        void UpdateReservation(String id, Reservation reservation);

        // Deletes a reservation by its ID.
        void DeleteReservation(String id);

        // Retrieves a list of reservations for a specific train by its ID.
        List<Reservation> GetReservationsByTrainID(String id);

        // Retrieves a list of reservations for a specific user by their ID.
        List<Reservation> GetReservationsByUserID(String id);
    }
}
