using Cwk.Domain.Entities;
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
    public class AmenityRepository(AppDbContext context) : IAmenityRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Amenity> AddAsync(Amenity amenity)
        {
            await _context.Amenities.AddAsync(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task<List<Amenity>> GetAllAsync()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenity> GetByIdAsync(int id)
        {
            return (await _context.Amenities.FindAsync(id))!;
        }

        public async Task UpdateAsync(Amenity amenity)
        {
            _context.Amenities.Update(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetBySpaceIdAsync(int spaceId)
        {
            return await _context.SpaceAmenities
                .Where(sa => sa.SpaceId == spaceId)
                .Select(sa => sa.Amenity)
                .ToListAsync();
        }
    }
}