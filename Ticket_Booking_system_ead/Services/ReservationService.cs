/*
* File: ReservationService.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file contains the implementation of the Reservation Service in the Ticket Booking System backend.
*/

using MongoDB.Driver;
using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservation;

        public ReservationService(ITicketBookingSystemStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _reservation = database.GetCollection<Reservation>(setting.ReservationCollectionName);
        }

        // Creates a new reservation.
        public Reservation CreateReservation(Reservation reservation)
        {
            _reservation.InsertOne(reservation);
            return reservation;
        }

        // Deletes a reservation by its ID.
        public void DeleteReservation(string id)
        {
            _reservation.DeleteOne(reservation => reservation.Id == id);
        }

        // Retrieves a reservation by its ID.
        public Reservation GetReservation(string id)
        {
            return _reservation.Find(reservation => reservation.Id == id).FirstOrDefault();
        }

        // Retrieves a list of all reservations.
        public List<Reservation> GetReservations()
        {
            return _reservation.Find(reservation => true).ToList();
        }

        // Updates an existing reservation by its ID.
        public void UpdateReservation(string id, Reservation reservation1)
        {
            _reservation.ReplaceOne(reservation => reservation.Id == id, reservation1);
        }

        // Retrieves a list of reservations for a specific train by its ID.
        public List<Reservation> GetReservationsByTrainID(string id)
        {
            return _reservation.Find(reservation => reservation.TrainID == id && reservation.Status).ToList();
        }

        // Retrieves a list of reservations for a specific user by their ID.
        public List<Reservation> GetReservationsByUserID(string id)
        {
            return _reservation.Find(reservation => reservation.UserID == id).ToList();
        }
    }
}
