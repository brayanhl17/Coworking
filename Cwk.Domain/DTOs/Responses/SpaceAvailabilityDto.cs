namespace Cwk.Domain.DTOs.Responses
{
    public class SpaceAvailabilityDto
    {
        public int SpaceId { get; set; }
        public bool IsAvailable { get; set; }
        public List<TimeSlot> AvailableSlots { get; set; } = new();
        public List<ReservationDetailsDto> ExistingReservations { get; set; } = new();
    }
}