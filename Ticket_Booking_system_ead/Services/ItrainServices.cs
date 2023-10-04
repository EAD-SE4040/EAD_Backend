using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public interface ItrainServices
    {
        List<Train> GetTrains();
        Train GetTrain(String id);

        Train CreateTrain(Train train);

        void UpdateTrain(String id ,Train train);

        void DeleteTrain(String id);


    }
}
