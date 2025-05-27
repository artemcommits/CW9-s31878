using Microsoft.AspNetCore.Mvc;
using PrescriptionApp.Services;

namespace PrescriptionApp.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientAsync(id);
            if (patient == null)
                return NotFound($"Patient with id {id} not found.");

            return Ok(patient);
        }
    }
}