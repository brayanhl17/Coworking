using Cwk.Business.Interfaces;
using Cwk.Domain.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmenitiesController(IAmenityService amenityService) : ControllerBase
    {
        private readonly IAmenityService _amenityService = amenityService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var amenities = await _amenityService.GetAllAmenitiesAsync();
            return Ok(amenities);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var amenity = await _amenityService.GetAmenityByIdAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return Ok(amenity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddAmenityDto amenityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAmenity = await _amenityService.CreateAmenityAsync(amenityDto);
            return CreatedAtAction(nameof(GetById), new { id = createdAmenity.Id }, createdAmenity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAmenityDto amenityDto)
        {
            if (id != amenityDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _amenityService.UpdateAmenityAsync(amenityDto);
            return NoContent();
        }

        [HttpGet("spaceId/{spaceId}")]
        public async Task<IActionResult> GetBySpaceId(int spaceId)
        {
            if (spaceId <= 0)
                return BadRequest("El identificador de espacio debe ser mayor a cero.");

            var amenities = await _amenityService.GetAmenitiesBySpaceIdAsync(spaceId);

            if (amenities == null || amenities.Count == 0)
                return NotFound($"No se encontraron amenities para el espacio con id {spaceId}.");

            return Ok(amenities);
        }
    }
}