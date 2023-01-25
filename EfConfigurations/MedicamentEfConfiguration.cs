using cwiczenia_8_s16325.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.EfConfigurations
{
    public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament);
            builder.Property(e => e.IdMedicament).UseIdentityColumn();
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Type).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Medicament { Name="Paracetamol", IdMedicament=1, Description="Bardzo silny lek, ostroznie!", Type="Ogolny"},
                new Medicament { Name = "Clatra", IdMedicament = 2, Description = "Lek na alergię", Type = "Alergie" },
                new Medicament { Name = "Telfexo", IdMedicament = 3, Description = "Lek na alergię", Type = "Alergie" },
                new Medicament { Name = "Fenistil", IdMedicament = 4, Description = "Żel", Type = "Ogolny" },
                new Medicament { Name = "Ibuprom", IdMedicament = 5, Description = "Bardzo silny lek, ostroznie!", Type = "Ogolny" }
                );


        }
    }
}
