using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;

namespace Cwk.Web.Services
{
    public interface IReservationClientService
    {
        Task<ReservationDetailsDto> CreateReservationAsync(CreateReservationRequestDto request);

        Task<ReservationResponseDto> GetReservationsAsync(ReservationQueryDto query);

        Task<SpaceAvailabilityDto> CheckSpaceAvailabilityAsync(int spaceId, DateTime startTime, DateTime endTime);

        Task<ReservationResponseDto> GetUserReservationsAsync(int userId);

        Task<bool> ConfirmReservationAsync(int reservationId);

        Task<bool> CancelReservationAsync(int reservationId);
    }
}