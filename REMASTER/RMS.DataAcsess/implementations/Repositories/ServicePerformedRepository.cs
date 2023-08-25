using Infrastructure.DataAccess.EF;
using RMS.DataAcsess.implementations.EF.Context;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.implementations.Repositories
{
    public class ServicePerformedRepository : BaseRepository<ServicePerformed, RemasteredContext>, IServicePerformedRepository
    {
        public async Task<List<ServicePerformed>> GetByDateAsync(DateTime date, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.ServiceDate == date, includeList);
        }

        public async Task<ServicePerformed> GetByIdAsync(int ServiceLogId, params string[] includeList)
        {
            return await GetAsync(rms => rms.ServiceLogID == ServiceLogId, includeList);
        }

        public async Task<List<ServicePerformed>> GetByServiceAsync(Service service, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Service == service, includeList);
        }

        public async Task<List<ServicePerformed>> GetByServiceIdAsync(int ServiceID, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.ServiceID == ServiceID, includeList);
        }

        public async Task<List<ServicePerformed>> GetByTechnicianIdAsync(int TechnicianID, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.TechnicianID == TechnicianID, includeList);
        }

        public async Task<List<ServicePerformed>> GetByVehicleIdAsync(int VehicleID, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.VehicleID == VehicleID, includeList);
        }
    }
}
