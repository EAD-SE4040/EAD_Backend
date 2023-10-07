namespace Ticket_Booking_system_Backend_EAD.Models
{
    public interface ITicketBookingSystemStoreDatabaseSetting
    {
        String TrainCollectionName { get; set; }
        String ReservationCollectionName { get; set; }
        String UserCollectionName { get; set; }
        String ConnectionString { get; set; }
        String DatabaseName { get; set; }
    }
}
