using Cwk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.Interfaces
{
    public interface ISpaceRepository
    {
        Task<Space> GetByIdAsync(int id);

        Task<List<Space>> GetAllAsync();

        Task<Space> AddAsync(Space space, List<int> ints);

        Task UpdateAsync(Space space, List<int> ints);

        Task DeleteAsync(int id);
    }
}