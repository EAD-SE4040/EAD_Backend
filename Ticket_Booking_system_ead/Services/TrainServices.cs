/*
* File: TrainServices.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file contains the implementation of the Train Service in the Ticket Booking System backend.
*/

using Ticket_Booking_system_Backend_EAD.Models;
using MongoDB.Driver;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public class TrainServices : ItrainServices
    {
        private readonly IMongoCollection<Train> _train;

        public TrainServices(ITicketBookingSystemStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _train = database.GetCollection<Train>(setting.TrainCollectionName);
        }

        // Creates a new train.
        public Train CreateTrain(Train train)
        {
            _train.InsertOne(train);
            return train;
        }

        // Deletes a train by its ID.
        public void DeleteTrain(string id)
        {
            _train.DeleteOne(train => train.Id == id);
        }

        // Retrieves a train by its ID.
        public Train GetTrain(string id)
        {
            return _train.Find(train => train.Id == id).FirstOrDefault();
        }

        // Retrieves a list of all trains.
        public List<Train> GetTrains()
        {
            return _train.Find(train => true).ToList();
        }

        // Updates an existing train by its ID.
        public void UpdateTrain(string id, Train train1)
        {
            _train.ReplaceOne(train => train.Id == id, train1);
        }
    }
}
