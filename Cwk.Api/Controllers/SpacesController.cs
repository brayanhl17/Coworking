using Cwk.Business.Interfaces;
using Cwk.Domain.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cwk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpacesController(ISpaceService spaceService) : ControllerBase
    {
        private readonly ISpaceService _spaceService = spaceService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var spaces = await _spaceService.GetAllSpacesAsync();
            return Ok(spaces);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var space = await _spaceService.GetSpaceByIdAsync(id);
            if (space == null)
            {
                return NotFound();
            }
            return Ok(space);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSpaceDto spaceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdSpace = await _spaceService.CreateSpaceAsync(spaceDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSpace.Id }, createdSpace);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EditSpaceDto spaceDto)
        {
            if (id != spaceDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _spaceService.UpdateSpaceAsync(spaceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _spaceService.DeleteSpaceAsync(id);
            return NoContent();
        }
    }
}