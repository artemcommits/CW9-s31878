using Microsoft.EntityFrameworkCore;
using PrescriptionApp.Data;
using PrescriptionApp.DTOs;

namespace PrescriptionApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetPatientDto?> GetPatientAsync(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.Doctor)
                .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
                .FirstOrDefaultAsync(p => p.IdPatient == id);

            if (patient == null) return null;

            return new GetPatientDto
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                Prescriptions = patient.Prescriptions
                    .OrderBy(p => p.DueDate)
                    .Select(p => new GetPrescriptionDto
                    {
                        IdPrescription = p.IdPrescription,
                        Date = p.Date,
                        DueDate = p.DueDate,
                        DoctorName = $"{p.Doctor.FirstName} {p.Doctor.LastName}",
                        Medicaments = p.PrescriptionMedicaments.Select(pm => new GetMedicamentDto
                        {
                            Name = pm.Medicament.Name,
                            Dose = pm.Dose,
                            Description = pm.Details
                        }).ToList()
                    }).ToList()
            };
        }
    }
}