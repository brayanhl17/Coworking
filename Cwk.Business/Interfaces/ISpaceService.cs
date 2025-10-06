using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;

namespace Cwk.Business.Interfaces
{
    public interface ISpaceService
    {
        Task<SpaceResponseDto> GetAllSpacesAsync();

        Task<SpaceDetailsDto> GetSpaceByIdAsync(int id);

        Task<SpaceDetailsDto> CreateSpaceAsync(AddSpaceDto spaceDto);

        Task UpdateSpaceAsync(EditSpaceDto spaceDto);

        Task DeleteSpaceAsync(int id);
    }
}