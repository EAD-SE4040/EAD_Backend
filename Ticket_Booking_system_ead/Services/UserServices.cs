/*
* File: UserServices.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file contains the implementation of the User Service in the Ticket Booking System backend.
*/

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

        // Creates a new user.
        public User CreateUser(User user)
        {
            user.Id = ObjectId.GenerateNewId().ToString(); // Generate a valid ObjectId string
            _user.InsertOne(user);
            return user;
        }

        // Deletes a user by its ID.
        public void DeleteUser(string id)
        {
            _user.DeleteOne(user => user.Id == id);
        }

        // Retrieves a user by its ID.
        public User GetUser(string id)
        {
            return _user.Find(user => user.Id == id).FirstOrDefault();
        }

        // Retrieves a list of all users.
        public List<User> GetUsers()
        {
            return _user.Find(user => true).ToList();
        }

        // Updates an existing user by its ID.
        public void UpdateUser(string id, User updatedUser)
        {
            // Ensure the Id of the updated user remains the same
            updatedUser.Id = id;
            _user.ReplaceOne(user => user.Id == id, updatedUser);
        }

        // Authenticates a user by their username and password.
        public User Authenticate(string username, string password)
        {
            var user = _user.Find(u => u.Email == username && u.Password == password).FirstOrDefault();

            return user;
        }
    }
}
