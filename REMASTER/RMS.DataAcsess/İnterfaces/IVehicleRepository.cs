using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        Task<List<Vehicle>> GetByMakeAsync(string make, params string[] includeList);
        Task<List<Vehicle>> GetByModelAsync(string model, params string[] includeList);
        Task<List<Vehicle>> GetByMileageAsync(int mil, params string[] includeList);
        Task<List<Vehicle>> GetByYearAsync(int year, params string[] includeList);
        Task<List<Vehicle>> GetByLicensePlateAsync(string plate, params string[] includeList);
        Task<List<Vehicle>> GetByCustomerAsync(int customerId, params string[] includeList);
        Task<Vehicle> GetByIdAsync(int vehicleId, params string[] includeList);
    }
}

