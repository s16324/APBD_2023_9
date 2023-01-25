using cwiczenia_8_s16325.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.EfConfigurations
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).UseIdentityColumn();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder.HasOne(e => e.IdDoctorNavigation)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor);

            builder.HasOne(e => e.IdPatientNavigation)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor);

            builder.HasData(
                new Prescription { IdPrescription = 1,IdDoctor =1, IdPatient=1, Date= DateTime.Now , DueDate= DateTime.Now.AddDays(14)},
                new Prescription { IdPrescription = 2, IdDoctor = 2, IdPatient = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(14) },
                new Prescription { IdPrescription = 3, IdDoctor = 3, IdPatient = 3, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(14) }
                );

        }
    }
}
