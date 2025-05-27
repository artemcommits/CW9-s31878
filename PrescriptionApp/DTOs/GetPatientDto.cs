namespace PrescriptionApp.DTOs
{
    public class GetPatientDto
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }

        public List<GetPrescriptionDto> Prescriptions { get; set; } = new();
    }
}