using AutoMapper;
using Cwk.Business.Interfaces;
using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;
using Cwk.Domain.Entities;
using Cwk.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Business.Services
{
    public class AmenityService(IAmenityRepository amenityRepository, IMapper mapper) : IAmenityService
    {
        private readonly IAmenityRepository _amenityRepository = amenityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<AmenityResponseDto> CreateAmenityAsync(AddAmenityDto amenityDto)
        {
            var amenity = _mapper.Map<Amenity>(amenityDto);
            var createdAmenity = await _amenityRepository.AddAsync(amenity);
            return _mapper.Map<AmenityResponseDto>(createdAmenity);
        }

        public async Task<List<AmenityResponseDto>> GetAllAmenitiesAsync()
        {
            var amenities = await _amenityRepository.GetAllAsync();
            return _mapper.Map<List<AmenityResponseDto>>(amenities);
        }

        public async Task<AmenityResponseDto> GetAmenityByIdAsync(int id)
        {
            var amenity = await _amenityRepository.GetByIdAsync(id);
            return _mapper.Map<AmenityResponseDto>(amenity);
        }

        public async Task UpdateAmenityAsync(UpdateAmenityDto amenityDto)
        {
            var amenity = _mapper.Map<Amenity>(amenityDto);
            await _amenityRepository.UpdateAsync(amenity);
        }

        public async Task<List<AmenityResponseDto>> GetAmenitiesBySpaceIdAsync(int spaceId)
        {
            var amenities = await _amenityRepository.GetBySpaceIdAsync(spaceId);
            return _mapper.Map<List<AmenityResponseDto>>(amenities);
        }
    }
}