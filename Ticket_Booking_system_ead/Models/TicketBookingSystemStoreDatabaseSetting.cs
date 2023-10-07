namespace Ticket_Booking_system_Backend_EAD.Models
{
    public class TicketBookingSystemStoreDatabaseSetting : ITicketBookingSystemStoreDatabaseSetting
    {
        public String TrainCollectionName { get; set; } = String.Empty;
        public String ReservationCollectionName { get; set; } = String.Empty;
        public String UserCollectionName { get; set; } = String.Empty;
        public String ConnectionString { get; set; } = String.Empty;
        public String DatabaseName { get; set; } = String.Empty;
    }
}
