using Case5_ClubSystem.DTOs;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case5_ClubSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 5, string? sortBy = "id")
        {
            var members = await _unitOfWork.Members.GetMembersAsync(
                pageNumber,
                pageSize,
                sortBy);

            var result = members.Select(m => new ReadMemberDto
            {
                Id = m.Id,
                FullName = m.FullName,
                Email = m.Email,
                Phone = m.Phone,
                BirthDate = m.BirthDate
            });

            return Ok(result);
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            var members = await _unitOfWork.Members.SearchByNameAsync(name);

            var result = members.Select(m => new ReadMemberDto
            {
                Id = m.Id,
                FullName = m.FullName,
                Email = m.Email,
                Phone = m.Phone,
                BirthDate = m.BirthDate
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberDto dto)
        {
            
            // Member must be at least 16 years old.

            var age = DateTime.Today.Year - dto.BirthDate.Year;

            if (dto.BirthDate.Date > DateTime.Today.AddYears(-age))
                age--;

            if (age < 16)
                return BadRequest("Member must be at least 16 years old.");

            var member = new Member
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                BirthDate = dto.BirthDate
            };

            await _unitOfWork.Members.AddAsync(member);

            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(
                nameof(GetAll),
                new { id = member.Id },
                member);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MemberDto dto)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
                return NotFound();

            var age = DateTime.Today.Year - dto.BirthDate.Year;

            if (dto.BirthDate.Date > DateTime.Today.AddYears(-age))
                age--;

            if (age < 16)
                return BadRequest("Member must be at least 16 years old.");

            member.FullName = dto.FullName;
            member.Email = dto.Email;
            member.Phone = dto.Phone;
            member.BirthDate = dto.BirthDate;

            _unitOfWork.Members.Update(member);

            await _unitOfWork.CompleteAsync();

            return Ok(member);
        }


    }
}
