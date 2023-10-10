using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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

        public User CreateUser(User user)
        {
            user.Id = ObjectId.GenerateNewId().ToString(); // Generate a valid ObjectId string
            _user.InsertOne(user);
            return user;
        }

        public void DeleteUser(string id)
        {
            _user.DeleteOne(user => user.Id == id);
        }

        public User GetUser(string id)
        {
            return _user.Find(user => user.Id == id).FirstOrDefault();
        }

        public User GetUserByNIC(string id)
        {
            return _user.Find(user => user.NIC == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _user.Find(user => true).ToList();
        }

        public void UpdateUser(string id, User updatedUser)
        {
            // Ensure the Id of the updated user remains the same
            updatedUser.Id = id;
            _user.ReplaceOne(user => user.Id == id, updatedUser);
        }

        public User Authenticate(string username, string password)
        {
            var user = _user.Find(u => u.Email == username && u.Password == password).FirstOrDefault();

            return user;
        }
    }
}
