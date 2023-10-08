using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public interface IUserServices
    {
        List<User> GetUsers();

        User GetUser(String id);

        User CreateUser(User user);

        void UpdateUser(String id, User user);

        void DeleteUser(String id);

        User Authenticate(string username, string password);
    }
}
