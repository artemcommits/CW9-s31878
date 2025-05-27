using Microsoft.AspNetCore.Mvc;
using PrescriptionApp.DTOs;
using PrescriptionApp.Services;

namespace PrescriptionApp.Controllers
{
    [ApiController]
    [Route("api/prescriptions")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] CreatePrescriptionDto dto)
        {
            try
            {
                await _prescriptionService.AddPrescriptionAsync(dto);
                return Ok("Prescription added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}