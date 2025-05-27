namespace PrescriptionApp.DTOs
{
    public class CreatePatientDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}