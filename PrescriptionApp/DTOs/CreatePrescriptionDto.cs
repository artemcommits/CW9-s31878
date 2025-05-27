namespace PrescriptionApp.DTOs
{
    public class CreatePrescriptionDto
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public CreatePatientDto Patient { get; set; } = null!;

        public int DoctorId { get; set; }

        public List<PrescribedMedicamentDto> Medicaments { get; set; } = new();
    }

    public class PrescribedMedicamentDto
    {
        public int MedicamentId { get; set; }
        public int Dose { get; set; }
        public string Description { get; set; } = null!;
    }
}