﻿using System.ComponentModel.DataAnnotations;

namespace PrescriptionApp.Models
{
    public class Medicament
    {
        [Key]
        public int IdMedicament { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;

        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
    }
}