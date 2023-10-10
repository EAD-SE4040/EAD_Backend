/*
* File: IUserServices.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the interface for the User Service in the Ticket Booking System backend.
*/

using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public interface IUserServices
    {
        // Retrieves a list of all users.
        List<User> GetUsers();

        // Retrieves a user by their ID.
        User GetUser(String id);

        // Creates a new user.
        User CreateUser(User user);

        // Updates an existing user by their ID.
        void UpdateUser(String id, User user);

        // Deletes a user by their ID.
        void DeleteUser(String id);

        // Authenticates a user by their username and password.
        User Authenticate(string username, string password);
    }
}
