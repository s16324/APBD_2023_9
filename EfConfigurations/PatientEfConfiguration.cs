using cwiczenia_8_s16325.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.EfConfigurations
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient);
            builder.Property(e => e.IdPatient).UseIdentityColumn();
            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.BirthDate).IsRequired();

            builder.HasData(
                new Patient { IdPatient = 1, FirstName = "Jan", LastName = "Kowalski", BirthDate = DateTime.Parse("01/01/1900") },
                new Patient { IdPatient = 2, FirstName = "Tomasz", LastName = "Kwiatkowski", BirthDate = DateTime.Parse("12/12/1990") },
                new Patient { IdPatient = 3, FirstName = "Janusz", LastName = "Zielinski", BirthDate = DateTime.Parse("11/11/1970") },
                new Patient { IdPatient = 4, FirstName = "Miroslaw", LastName = "Dzem", BirthDate = DateTime.Parse("08/05/1969") }
                );
        }
    }
}
