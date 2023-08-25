using Infrastructure.DataAccess.EF;
using RMS.DataAcsess.implementations.EF.Context;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RMS.DataAcsess.implementations.Repositories
{
    public class TechnicianRepository : BaseRepository<Technician, RemasteredContext>, ITechnicianRepository
    {
        public async Task<Technician> GetByIdAsync(int technicianId, params string[] includeList)
        {
            return await GetAsync(rms => rms.TechnicianID == technicianId, includeList);
        }

        public async Task<List<Technician>> GetByLastNameAsync(string lastName, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.LastName == lastName, includeList);
        }

        public async Task<List<Technician>> GetByMailAsync(string mail, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Email == mail, includeList);
        }

        public async Task<List<Technician>> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.FirstName == name, includeList);
        }

        public async Task<List<Technician>> GetByPhoneAsync(string phone, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.PhoneNumber == phone, includeList);
        }
    }
}
