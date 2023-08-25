using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface ITechnicianRepository : IBaseRepository<Technician>
    {
        Task<List<Technician>> GetByNameAsync(string name, params string[] includeList);
        Task<List<Technician>> GetByLastNameAsync(string lastName, params string[] includeList);
        Task<List<Technician>> GetByMailAsync(string mail, params string[] includeList);
        Task<List<Technician>> GetByPhoneAsync(string phone, params string[] includeList);
        Task<Technician> GetByIdAsync(int technicianId, params string[] includeList);
    }
}
