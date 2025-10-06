using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Business.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationResponseDto> GetReservationsAsync(ReservationQueryDto query);

        Task<ReservationDetailsDto?> GetReservationByIdAsync(int id);

        Task<ReservationDetailsDto> CreateReservationAsync(CreateReservationRequestDto request);

        Task<ReservationDetailsDto> UpdateReservationAsync(UpdateReservationRequestDto request);

        Task<bool> DeleteReservationAsync(int id);

        Task<SpaceAvailabilityDto> CheckSpaceAvailabilityAsync(int spaceId, DateTime startTime, DateTime endTime);

        Task<bool> ConfirmReservationAsync(int reservationId);

        Task<bool> CancelReservationAsync(int reservationId);
    }
}