using PrescriptionApp.DTOs;

namespace PrescriptionApp.Services
{
    public interface IPrescriptionService
    {
        Task AddPrescriptionAsync(CreatePrescriptionDto dto);
    }
}