using Case5_ClubSystem.DTOs;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case5_ClubSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDto dto)
        {
            if (dto.EndTime <= dto.StartTime)
                return BadRequest("End time must be greater than Start time.");

            var member = await _unitOfWork.Members.GetByIdAsync(dto.MemberId);

            if (member == null)
                return NotFound("Member not found.");

            var facility = await _unitOfWork.Facilities.GetByIdAsync(dto.FacilityId);

            if (facility == null)
                return NotFound("Facility not found.");

            if (dto.GroupSize > facility.Capacity)
                return BadRequest("Group size exceeds facility capacity.");

            var booking = new Booking
            {
                BookingDate = DateTime.Now,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                GroupSize = dto.GroupSize,
                Status = "Confirmed",
                MemberId = dto.MemberId,
                FacilityId = dto.FacilityId
            };

            await _unitOfWork.Bookings.AddAsync(booking);

            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = booking.Id },
                new ReadBookingDto
                {
                    Id = booking.Id,
                    BookingDate = booking.BookingDate,
                    StartTime = booking.StartTime,
                    EndTime = booking.EndTime,
                    GroupSize = booking.GroupSize,
                    Status = booking.Status,
                    MemberName = member.FullName,
                    FacilityName = facility.Name
                });
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll(
            int pageNumber = 1,
            int pageSize = 5,
            string? status = null,
            int? facilityId = null)
        {
            var bookings = await _unitOfWork.Bookings.GetBookingsAsync(
                pageNumber,
                pageSize,
                status,
                facilityId);

            var result = bookings.Select(b => new ReadBookingDto
            {
                Id = b.Id,
                BookingDate = b.BookingDate,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                GroupSize = b.GroupSize,
                Status = b.Status,
                MemberName = b.Member.FullName,
                FacilityName = b.Facility.Name
            });

            return Ok(result);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _unitOfWork.Bookings.GetBookingByIdAsync(id);

            if (booking == null)
                return NotFound();

            return Ok(new ReadBookingDto
            {
                Id = booking.Id,
                BookingDate = booking.BookingDate,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                GroupSize = booking.GroupSize,
                Status = booking.Status,
                MemberName = booking.Member.FullName,
                FacilityName = booking.Facility.Name
            });
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookingDto dto)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);

            if (booking == null)
                return NotFound();

            if (dto.EndTime <= dto.StartTime)
                return BadRequest("End time must be greater than Start time.");

            var facility = await _unitOfWork.Facilities.GetByIdAsync(booking.FacilityId);

            if (dto.GroupSize > facility.Capacity)
                return BadRequest("Group size exceeds facility capacity.");

            booking.BookingDate = dto.BookingDate;
            booking.StartTime = dto.StartTime;
            booking.EndTime = dto.EndTime;
            booking.GroupSize = dto.GroupSize;
            booking.Status = dto.Status;

            _unitOfWork.Bookings.Update(booking);

            await _unitOfWork.CompleteAsync();

            return Ok(new ReadBookingDto
            {
                Id = booking.Id,
                BookingDate = booking.BookingDate,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                GroupSize = booking.GroupSize,
                Status = booking.Status,
                MemberName = booking.Member.FullName,
                FacilityName = facility.Name
            });
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);

            if (booking == null)
                return NotFound();

            await _unitOfWork.Bookings.DeleteAsync(id);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        

        [HttpGet("report")]
        public async Task<IActionResult> Report()
        {
            var report = await _unitOfWork.Bookings.GetBookingReportAsync();

            return Ok(report);
        }

     

        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);

            if (booking == null)
                return NotFound();

            if (booking.Status == "Cancelled")
                return BadRequest("Booking is already cancelled.");

            await _unitOfWork.Bookings.CancelBookingAsync(id);

            await _unitOfWork.CompleteAsync();

            return Ok("Booking cancelled successfully.");
        }
    }
}
