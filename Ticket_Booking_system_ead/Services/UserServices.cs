using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMongoCollection<User> _User;

        public UserServices(ITicketBookingSystemStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _User = database.GetCollection<User>(setting.UserCollectionName);
        }
        public  User CreateUser(User user)
        {
            _User.InsertOne(user);
            return user; ;
        }

        public User GetUser(string id)
        {
            return _User.Find(user => user.Id == id).FirstOrDefault();
        }
    }
}
