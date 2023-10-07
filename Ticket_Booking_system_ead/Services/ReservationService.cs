using MongoDB.Driver;
using Ticket_Booking_system_Backend_EAD.Models;

namespace Ticket_Booking_system_Backend_EAD.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservation;

        public ReservationService(ITicketBookingSystemStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _reservation = database.GetCollection<Reservation>(setting.ReservationCollectionName);

        }
        public Reservation CreateReservation(Reservation reservation)
        {
            _reservation.InsertOne(reservation);
            return reservation;
        }

        public void DeleteReservation(string id)
        {
            _reservation.DeleteOne(reservation => reservation.Id == id);
        }

        public Reservation GetReservation(string id)
        {
            return _reservation.Find(reservation => reservation.Id == id).FirstOrDefault();
        }

        public List<Reservation> GetReservations()
        {

            return _reservation.Find(reservation => true).ToList();
        }

        public void UpdateReservation(string id, Reservation reservation1)
        {
            _reservation.ReplaceOne(reservation => reservation.Id == id, reservation1);
        }
    }
}
