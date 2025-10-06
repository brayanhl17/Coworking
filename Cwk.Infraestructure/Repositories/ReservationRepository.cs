using Cwk.Domain.Entities;
using Cwk.Domain.Enums;
using Cwk.Domain.Interfaces;
using Cwk.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Infraestructure.Repositories
{
    public class ReservationRepository(AppDbContext context) : IReservationRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Reservation> AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.Space)
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetAvailables(int spaceId, DateTime startTime, DateTime endTime)
        {
            var existingReservations = await _context.Reservations
             .Where(r => r.SpaceId == spaceId &&
                        r.ReservationStatus != ReservationStatus.Cancelled &&
                        ((r.StartTime <= startTime && r.EndTime > startTime) ||
                         (r.StartTime < endTime && r.EndTime >= endTime) ||
                         (r.StartTime >= startTime && r.EndTime <= endTime)))
             .Include(r => r.User)
             .ToListAsync();

            return existingReservations;
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            return reservation!;
        }

        public Task<List<Reservation>> GetBySpaceIdAsync(int spaceId)
        {
            var reservations = _context.Reservations
                .Where(r => r.SpaceId == spaceId)
                .ToListAsync();
            return reservations;
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}