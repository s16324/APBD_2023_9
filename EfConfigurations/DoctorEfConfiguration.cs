using cwiczenia_8_s16325.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.EfConfigurations
{
    public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor);
            builder.Property(e => e.IdDoctor).UseIdentityColumn();
            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(e => e.Email).IsUnique();

            builder.HasData(
                new Doctor { IdDoctor = 1, FirstName = "Jakub", LastName = "Lewandowski", Email = "s16324@pjwstk.edu.pl"},
                new Doctor { IdDoctor = 2, FirstName = "Basz", LastName = "Kot", Email = "glodny@tunczyk.pl" },
                new Doctor { IdDoctor = 3, FirstName = "Dona", LastName = "Kot", Email = "miaaau@maruda.xd" }
                );
        }
    }
}
