using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Dtos.ServicePerformed;
using RMS.Model.Dtos.Vehicle;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Service;

namespace RMS.Business.İnterfaces
{
    public interface IServiceBs
    {
        Task<ApiResponse<List<ServiceGetDto>>> GetServicesAsync(params string[] includeList);
        Task<ApiResponse<List<ServiceGetDto>>> GetServicesByPriceAsync(decimal min,decimal max , params string[] includeList);
        Task<ApiResponse<List<ServiceGetDto>>> GetServicesByDescAsync(string desc, params string[] includeList);
        Task<ApiResponse<List<ServiceGetDto>>> GetVehiclesByNameAsync(string name, params string[] includeList);
        Task<ApiResponse<ServiceGetDto>> GetByIdAsync(int serviceId, params string[] includeList);

        Task<ApiResponse<Service>> InsertAsync(ServicePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ServicePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
