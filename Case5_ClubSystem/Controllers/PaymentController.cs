using Case5_ClubSystem.DTOs;
using Case5_ClubSystem.Models;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case5_ClubSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;


        public PaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> Create(PaymentDto dto)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(dto.MembershipId);

            if (membership == null)
                return NotFound("Membership not found.");

            var payment = new Payment
            {
                Amount = dto.Amount,
                PaymentDate = dto.PaymentDate,
                PaymentMethod = dto.PaymentMethod,
                MembershipId = dto.MembershipId
            };

            await _unitOfWork.Payments.AddAsync(payment);

            await _unitOfWork.CompleteAsync();

            return Ok(dto);
        }



        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var statistics = await _unitOfWork.Payments.GetStatisticsAsync();

            return Ok(statistics);
        }

    }
}
