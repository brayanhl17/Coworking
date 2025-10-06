using Cwk.Domain.Entities;
using Cwk.Domain.Interfaces;
using Cwk.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cwk.Infraestructure.Repositories
{
    public class SpaceRepository(AppDbContext context) : ISpaceRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Space> AddAsync(Space space, List<int> ints)
        {
            await _context.Spaces.AddAsync(space);
            await _context.SaveChangesAsync();
            var spaceAmenities = ints.Select(aid => new SpaceAmenity
            {
                SpaceId = space.Id,
                AmenityId = aid
            }).ToList();
            await _context.SpaceAmenities.AddRangeAsync(spaceAmenities);
            await _context.SaveChangesAsync();
            return space;
        }

        public async Task DeleteAsync(int id)
        {
            var space = await _context.Spaces.FindAsync(id);
            if (space != null)
            {
                _context.Spaces.Remove(space);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Space>> GetAllAsync()
        {
            return await _context.Spaces.ToListAsync();
        }

        public async Task<Space> GetByIdAsync(int id)
        {
            var space = await _context.Spaces
                .FirstOrDefaultAsync(s => s.Id == id);

            return space!;
        }

        public async Task UpdateAsync(Space space, List<int> ints)
        {
            _context.Spaces.Update(space);
            await _context.SaveChangesAsync();
            var spaceAmenities = ints.Select(aid => new SpaceAmenity
            {
                SpaceId = space.Id,
                AmenityId = aid
            }).ToList();
            _context.SpaceAmenities.RemoveRange(_context.SpaceAmenities.Where(sa => sa.SpaceId == space.Id));
            await _context.SpaceAmenities.AddRangeAsync(spaceAmenities);
            await _context.SaveChangesAsync();
        }
    }
}