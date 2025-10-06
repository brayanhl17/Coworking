using AutoMapper;
using Cwk.Application.Interfaces;
using Cwk.Business.Interfaces;
using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;
using Cwk.Domain.Entities;
using Cwk.Domain.Interfaces;

namespace Cwk.Business.Services
{
    public class SpaceService(ISpaceRepository spaceRepository, IMapper mapper, IPhotoService photoService) : ISpaceService
    {
        private readonly ISpaceRepository _spaceRepository = spaceRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IPhotoService _photoService = photoService;

        public async Task<SpaceDetailsDto> CreateSpaceAsync(AddSpaceDto spaceDto)
        {
            var space = _mapper.Map<Space>(spaceDto);
            if (spaceDto.ImageUrl != null)
            {
                space.ImageUrl = await _photoService.UploadImage(spaceDto.ImageUrl);
            }
            var createdSpace = await _spaceRepository.AddAsync(space, spaceDto.AmenityIds);
            return _mapper.Map<SpaceDetailsDto>(createdSpace);
        }

        public async Task DeleteSpaceAsync(int id)
        {
            await _spaceRepository.DeleteAsync(id);
        }

        public async Task<SpaceResponseDto> GetAllSpacesAsync()
        {
            var spaces = await _spaceRepository.GetAllAsync();
            var spaceDtos = _mapper.Map<List<SpaceDetailsDto>>(spaces);
            return new SpaceResponseDto { Spaces = spaceDtos };
        }

        public async Task<SpaceDetailsDto> GetSpaceByIdAsync(int id)
        {
            var space = await _spaceRepository.GetByIdAsync(id);
            return _mapper.Map<SpaceDetailsDto>(space);
        }

        public async Task UpdateSpaceAsync(EditSpaceDto spaceDto)
        {
            var spaceDb = await _spaceRepository.GetByIdAsync(spaceDto.Id);

            if (!string.IsNullOrEmpty(spaceDto.ImageUrl))
            {
                // Si hay una nueva imagen, súbela y actualiza la propiedad
                spaceDto.ImageUrl = await _photoService.UploadImage(spaceDto.ImageUrl);
            }

            _mapper.Map(spaceDto, spaceDb);
            await _spaceRepository.UpdateAsync(spaceDb, spaceDto.AmenityIds);
        }
    }
}