using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Technician;

namespace RMS.Business.İnterfaces
{
    public interface ITechnicianBs
    {
        Task<ApiResponse<List<TechnicianGetDto>>> GetTechniciansAsync(params string[] includeList);
  
        Task<ApiResponse<TechnicianGetDto>> GetByIdAsync(int technicianId, params string[] includeList);

        Task<ApiResponse<Technician>> InsertAsync(TechnicianPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(TechnicianPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

   




    }
}
