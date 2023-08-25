using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Entities;
using RMS.Model.Dtos.Vehicle;

namespace RMS.Business.İnterfaces
{
    public interface IVehicleBs
    {
        Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesAsync(params string[] includeList);
        Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesByYearAsync(int min, int max, params string[] includeList);
        Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesByCustomerAsync(int cutomerId, params string[] includeList);
        Task<ApiResponse<VehicleGetDto>> GetByIdAsync(int vehicleId, params string[] includeList);

        Task<ApiResponse<Vehicle>> InsertAsync(VehiclePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(VehiclePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        
    }
}
