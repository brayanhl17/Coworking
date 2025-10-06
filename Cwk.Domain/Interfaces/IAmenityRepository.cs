using Cwk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.Interfaces
{
    public interface IAmenityRepository
    {
        Task<Amenity> GetByIdAsync(int id);

        Task<List<Amenity>> GetAllAsync();

        Task<Amenity> AddAsync(Amenity amenity);

        Task UpdateAsync(Amenity amenity);

        Task<List<Amenity>> GetBySpaceIdAsync(int spaceId);
    }
}