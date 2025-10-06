using Cwk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> GetByIdAsync(int id);

        Task<List<Reservation>> GetAvailables(int spaceId, DateTime startTime, DateTime endTime);

        Task<List<Reservation>> GetAllAsync();

        Task<Reservation> AddAsync(Reservation reservation);

        Task UpdateAsync(Reservation reservation);

        Task<List<Reservation>> GetBySpaceIdAsync(int spaceId);
    }
}