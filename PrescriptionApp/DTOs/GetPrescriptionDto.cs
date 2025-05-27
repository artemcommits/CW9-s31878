namespace PrescriptionApp.DTOs
{
    public class GetPrescriptionDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public string DoctorName { get; set; } = null!;
        public List<GetMedicamentDto> Medicaments { get; set; } = new();
    }

    public class GetMedicamentDto
    {
        public string Name { get; set; } = null!;
        public int Dose { get; set; }
        public string Description { get; set; } = null!;
    }
}