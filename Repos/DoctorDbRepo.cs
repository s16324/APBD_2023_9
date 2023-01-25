using cwiczenia_8_s16325.DTO;
using cwiczenia_8_s16325.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.Repos
{
    public class DoctorDbRepo : IDoctorDbRepo
    {
        private readonly MainDbContext context;
        public DoctorDbRepo(MainDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            return await context.Doctor.Select(e => new DoctorDTO
            {
                IdDoctor = e.IdDoctor,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).ToListAsync();

        }

        public async Task<string> AddDoctor(DoctorDTO reqBody)
        {
            await context.AddAsync(new Doctor
            {
                FirstName = reqBody.FirstName,
                LastName = reqBody.LastName,
                Email = reqBody.Email
            });
            await context.SaveChangesAsync();
            return "Dodano rekord";
        }
        public async Task<string> UpdateDoctor(int id, DoctorDTO reqBody)
        {
            var doctor = await context.Doctor.FindAsync(id);
            if (doctor!=null)
            {
                doctor.FirstName = reqBody.FirstName;
                doctor.LastName = reqBody.LastName;
                doctor.Email = reqBody.Email;
                await context.SaveChangesAsync();
            }
            else
            {
                return "Brak rekordu o podanym id";
            }
            return "Zaktualizowano dane";
        }
        public async Task<string> DeleteDoctor(int id)
        {
            var doctor = await context.Doctor.FindAsync(id);
            if (doctor != null)
            {
                context.Remove(doctor);
                await context.SaveChangesAsync();
            }
            else
            {
                return "Brak rekordu o podanym id";
            }
            return "Usunięto rekord";
        }
    }
}
