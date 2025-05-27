using PrescriptionApp.DTOs;

namespace PrescriptionApp.Services
{
    public interface IPatientService
    {
        Task<GetPatientDto?> GetPatientAsync(int id);
    }
}