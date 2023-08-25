using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces

{  public interface IServicePerformedRepository : IBaseRepository<ServicePerformed>
    {
        Task<List<ServicePerformed>> GetByTechnicianIdAsync(int TechnicianID, params string[] includeList);
        Task<List<ServicePerformed>> GetByVehicleIdAsync(int VehicleID, params string[] includeList);
        Task<List<ServicePerformed>> GetByServiceIdAsync(int ServiceID, params string[] includeList);
        Task<List<ServicePerformed>> GetByDateAsync(DateTime date, params string[] includeList);
        Task<List<ServicePerformed>> GetByServiceAsync(Service service, params string[] includeList);
        Task<ServicePerformed> GetByIdAsync(int ServiceLogId, params string[] includeList);
    }
}
