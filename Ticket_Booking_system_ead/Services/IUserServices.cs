using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public interface IUserServices
    {
        User GetUser(String id);

        User CreateUser(User user);
    }
}
