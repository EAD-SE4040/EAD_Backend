using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMongoCollection<User> _user;

        public UserServices(ITicketBookingSystemStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _user = database.GetCollection<User>(setting.UserCollectionName);
        }
        public  User CreateUser(User user)
        {
            _user.InsertOne(user);
            return user; ;
        }

        public void DeleteUser(string id)
        {
            _user.DeleteOne(user => user.Id == id);
        }

        public User GetUser(string id)
        {
            return _user.Find(user => user.Id == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {

            return _user.Find(user => true).ToList();
        }

        public void UpdateUser(string id, User user1)
        {
            _user.ReplaceOne(user => user.Id == id, user1);
        }
    }
}
