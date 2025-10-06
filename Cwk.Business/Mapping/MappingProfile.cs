using AutoMapper;
using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;
using Cwk.Domain.Entities;

namespace Cwk.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDto>();

            CreateMap<AddSpaceDto, Space>();
            CreateMap<EditSpaceDto, Space>();
            CreateMap<Space, SpaceDetailsDto>();

            CreateMap<Amenity, AmenityResponseDto>();
            CreateMap<AddAmenityDto, Amenity>();
            CreateMap<UpdateAmenityDto, Amenity>();

            CreateMap<Reservation, ReservationDetailsDto>();
            CreateMap<CreateReservationRequestDto, Reservation>();
            CreateMap<UpdateReservationRequestDto, Reservation>();
        }
    }
}