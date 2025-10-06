using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Business.Interfaces
{
    public interface IAmenityService
    {
        Task<List<AmenityResponseDto>> GetAllAmenitiesAsync();

        Task<AmenityResponseDto> GetAmenityByIdAsync(int id);

        Task<AmenityResponseDto> CreateAmenityAsync(AddAmenityDto amenityDto);

        Task UpdateAmenityAsync(UpdateAmenityDto amenityDto);

        Task<List<AmenityResponseDto>> GetAmenitiesBySpaceIdAsync(int spaceId);
    }
}