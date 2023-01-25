using cwiczenia_8_s16325.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.Repos
{
    public interface IDoctorDbRepo
    {
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<string> AddDoctor(DoctorDTO reqBody);
        Task<string> UpdateDoctor(int id, DoctorDTO reqBody);
        Task<string> DeleteDoctor(int id);

    }
}
