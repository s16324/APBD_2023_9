using cwiczenia_8_s16325.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.Repos
{
    public interface IPrescriptionDbRepo
    {
        Task<PrescriptionDTO> GetPrescription(int id);
    }
}
