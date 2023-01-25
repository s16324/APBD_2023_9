using cwiczenia_8_s16325.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.EfConfigurations
{
    public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("Prescription_Medicament");
            builder.HasKey(e => new
            {
                e.IdMedicament,
                e.IdPrescription
            });
            builder.Property(e => e.Details).HasMaxLength(100).IsRequired();

            builder.HasOne(e => e.IdMedicamentNavigation)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament);

            builder.HasOne(e => e.IdPrescriptionNavigation)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription);

            builder.HasData(
                new PrescriptionMedicament { IdMedicament=1, IdPrescription=1, Dose=12, Details="Szybko popic"},
                new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 1, Dose = 2, Details = "Co dwa dni" },
                new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 2, Dose = 2137, Details = "stosowac wg uznania" }
                );
        }
    }
}
