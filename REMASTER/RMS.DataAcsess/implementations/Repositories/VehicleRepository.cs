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
    public class VehicleRepository : BaseRepository<Vehicle, RemasteredContext>, IVehicleRepository
    {
        public async Task<List<Vehicle>> GetByCustomerAsync(int customerId, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.CustomerID == customerId, includeList);
        }

        public async Task<Vehicle> GetByIdAsync(int vehicleId, params string[] includeList)
        {
            return await GetAsync(rms => rms.VehicleID == vehicleId, includeList);
        }

        public async Task<List<Vehicle>> GetByLicensePlateAsync(string plate, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.LicensePlate == plate, includeList);
        }

        public async Task<List<Vehicle>> GetByMakeAsync(string make, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Make == make, includeList);
        }

        public async Task<List<Vehicle>> GetByMileageAsync(int mil, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Mileage == mil, includeList);
        }

        public async Task<List<Vehicle>> GetByModelAsync(string model, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Model == model, includeList);
        }

        public async Task<List<Vehicle>> GetByYearAsync(int year, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Year == year, includeList);
        }
    }
}
