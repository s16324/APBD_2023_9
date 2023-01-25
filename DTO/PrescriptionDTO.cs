using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.DTO
{
    public class PrescriptionDTO
    {
        public int IdPrescription { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
        public IEnumerable<MedicamentDTO> Medicaments { get; set; }

    }
}
