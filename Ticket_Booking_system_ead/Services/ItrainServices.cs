/*
* File: ItrainServices.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the interface for the Train Service in the Ticket Booking System backend.
*/

using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public interface ItrainServices
    {
        // Retrieves a list of all trains.
        List<Train> GetTrains();

        // Retrieves a train by its ID.
        Train GetTrain(String id);

        // Creates a new train.
        Train CreateTrain(Train train);

        // Updates an existing train by its ID.
        void UpdateTrain(String id, Train train);

        // Deletes a train by its ID.
        void DeleteTrain(String id);
    }
}
