using Case5_ClubSystem.DTOs;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case5_ClubSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public FacilityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll(string? sortBy)
        {
            var facilities = await _unitOfWork.Facilities.GetFacilitiesAsync(sortBy);

            var result = facilities.Select(f => new ReadFacilityDto
            {
                Id = f.Id,
                Name = f.Name,
                Capacity = f.Capacity,
                HourlyPrice = f.HourlyPrice
            });

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var facility = await _unitOfWork.Facilities.GetByIdAsync(id);

            if (facility == null)
                return NotFound();

            var result = new ReadFacilityDto
            {
                Id = facility.Id,
                Name = facility.Name,
                Capacity = facility.Capacity,
                HourlyPrice = facility.HourlyPrice
            };

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(FacilityDto dto)
        {
            var facility = new Facility
            {
                Name = dto.Name,
                Capacity = dto.Capacity,
                HourlyPrice = dto.HourlyPrice
            };

            await _unitOfWork.Facilities.AddAsync(facility);

            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = facility.Id },
                new ReadFacilityDto
                {
                    Id = facility.Id,
                    Name = facility.Name,
                    Capacity = facility.Capacity,
                    HourlyPrice = facility.HourlyPrice
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FacilityDto dto)
        {
            var facility = await _unitOfWork.Facilities.GetByIdAsync(id);

            if (facility == null)
                return NotFound();

            facility.Name = dto.Name;
            facility.Capacity = dto.Capacity;
            facility.HourlyPrice = dto.HourlyPrice;

            _unitOfWork.Facilities.Update(facility);

            await _unitOfWork.CompleteAsync();

            return Ok(new ReadFacilityDto
            {
                Id = facility.Id,
                Name = facility.Name,
                Capacity = facility.Capacity,
                HourlyPrice = facility.HourlyPrice
            });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var facility = await _unitOfWork.Facilities.GetByIdAsync(id);

            if (facility == null)
                return NotFound();

            bool hasBookings = await _unitOfWork.Facilities.HasBookingsAsync(id);

            if (hasBookings)
                return BadRequest("Cannot delete a facility that has bookings.");

            await _unitOfWork.Facilities.DeleteAsync(id);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
