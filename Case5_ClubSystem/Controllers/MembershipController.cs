using Case5_ClubSystem.DTOs;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case5_ClubSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;

        public MembershipController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet("active")]
        public async Task<IActionResult> GetActiveMemberships()
        {
            var memberships = await _unitOfWork.Memberships.GetActiveMembershipsAsync();

            var result = memberships.Select(m => new ReadMembershipDto
            {
                Id = m.Id,
                Type = m.Type,
                StartDate = m.StartDate,
                EndDate = m.EndDate,
                Price = m.Price,
                Status = m.Status,
                MemberName = m.Member.FullName
            });

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(MembershipDto dto)
        {
            if (dto.EndDate <= dto.StartDate)
                return BadRequest("End date must be greater than Start date.");

            var member = await _unitOfWork.Members.GetByIdAsync(dto.MemberId);

            if (member == null)
                return NotFound("Member not found.");

            var membership = new Membership
            {
                Type = dto.Type,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Price = dto.Price,
                Status = dto.Status,
                MemberId = dto.MemberId
            };

            await _unitOfWork.Memberships.AddAsync(membership);

            await _unitOfWork.CompleteAsync();

            return Ok(dto);
        }



        [HttpPatch("{id}/renew")]
        public async Task<IActionResult> Renew(int id)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(id);

            if (membership == null)
                return NotFound();

            await _unitOfWork.Memberships.RenewMembershipAsync(id);

            await _unitOfWork.CompleteAsync();

            return Ok("Membership renewed successfully.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(id);

            if (membership == null)
                return NotFound();

            await _unitOfWork.Memberships.DeleteAsync(id);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

    }

}
