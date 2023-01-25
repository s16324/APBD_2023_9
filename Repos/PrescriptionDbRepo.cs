using cwiczenia_8_s16325.DTO;
using cwiczenia_8_s16325.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia_8_s16325.Repos
{
    public class PrescriptionDbRepo : IPrescriptionDbRepo
    {
        private readonly MainDbContext context;

        public PrescriptionDbRepo(MainDbContext context)
        {
            this.context = context;
        }
        public async Task<PrescriptionDTO> GetPrescription(int id)
        {
            var prescription = await context.Prescription.FindAsync(id);

            if (prescription != null)
            {

                PrescriptionDTO presc = await context.Prescription.Where(e => e.IdPrescription == id).Select(p => new PrescriptionDTO
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new DoctorDTO
                    {
                        IdDoctor = p.IdDoctor,
                        FirstName = p.IdDoctorNavigation.FirstName,
                        LastName = p.IdDoctorNavigation.LastName,
                        Email = p.IdDoctorNavigation.Email
                    },
                    Patient = new PatientDTO
                    {
                        IdPatient = p.IdPatient,
                        FirstName = p.IdPatientNavigation.FirstName,
                        LastName = p.IdPatientNavigation.LastName,
                        BirthDate = p.IdPatientNavigation.BirthDate
                    },
                    Medicaments = p.PrescriptionMedicaments.Select(p => new MedicamentDTO
                    {
                        Name = p.IdMedicamentNavigation.Name,
                        Description = p.IdMedicamentNavigation.Description,
                        Type = p.IdMedicamentNavigation.Type
                    })
                }).FirstAsync();

                return presc;
            }
            else
            {
                return null;
            }
        }
    }
}
