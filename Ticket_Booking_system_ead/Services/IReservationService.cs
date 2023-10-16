using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public interface IReservationService
    {
        List<Reservation> GetReservations();
        Reservation GetReservation(String id);

        Reservation CreateReservation(Reservation reservation);

        void UpdateReservation(String id, Reservation reservation);

        void DeleteReservation(String id);

        List<Reservation> GetReservationsByTrainID(String id);

        List<Reservation> GetReservationsByUserID(String id);

        List<Reservation> GetReservationsByNIC(String id);
    }
}
