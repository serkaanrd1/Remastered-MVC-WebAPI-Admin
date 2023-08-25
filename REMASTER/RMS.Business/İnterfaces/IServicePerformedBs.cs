using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Dtos.Vehicle;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Service;
using RMS.Model.Dtos.ServicePerformed;

namespace RMS.Business.İnterfaces
{
    public interface IServicePerformedBs
    {
        Task<ApiResponse<List<ServicePerformedGetDto>>> GetServicesPerformedAsync(params string[] includeList);
        Task<ApiResponse<List<ServicePerformedGetDto>>> GetServicesPerformedByDateAsync(DateTime date, params string[] includeList);
        Task<ApiResponse<List<ServicePerformedGetDto>>> GetServicesPerformedByServiceAsync(int serviceId, params string[] includeList);
        Task<ApiResponse<List<ServicePerformedGetDto>>> GetServicesPerformedByVehiclesAsync(int vehicleId, params string[] includeList);
        Task<ApiResponse<ServicePerformedGetDto>> GetByIdAsync(int serviceLogId, params string[] includeList);

        Task<ApiResponse<ServicePerformed>> InsertAsync(ServicePerformedPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ServicePerformedPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);



    }
}
