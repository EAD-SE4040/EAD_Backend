using Ticket_Booking_system_Backend_EAD.Models;

using MongoDB.Driver;
using MongoDB.Bson;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public class TrainServices : ItrainServices
    {
        private readonly IMongoCollection<Train> _train;

        public TrainServices(ITicketBookingSystemStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
           var database =  mongoClient.GetDatabase(setting.DatabaseName);
           _train =  database.GetCollection<Train>(setting.TrainCollectionName);

        }
        public Train CreateTrain(Train train)
        {
            _train.InsertOne(train);
            return train;
        }

        public void DeleteTrain(string id)
        {
             _train.DeleteOne(train => train.Id == id);
        }

        public Train GetTrain(string id)
        {
            return _train.Find(train => train.Id == id).FirstOrDefault();
        }

        public List<Train> GetTrains()
        {
        
            return _train.Find(train => true).ToList();
        }

        public void UpdateTrain(string id,Train train1)
        {
            _train.ReplaceOne(train => train.Id == id,train1);
        }


 

    }
}
