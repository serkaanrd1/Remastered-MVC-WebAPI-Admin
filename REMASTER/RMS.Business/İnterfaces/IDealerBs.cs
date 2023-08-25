using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Dealer;

namespace RMS.Business.İnterfaces
{
    public interface IDealerBs 
    {
       Task<ApiResponse<List<DealerGetDto>>> GetDealersAsync(params string[] includeList);
       Task<ApiResponse<DealerGetDto>>GetByIdAsync(int dealerId, params string[] includeList);
       Task<ApiResponse<Dealer>> InsertAsync(DealerPostDto dto);
       Task<ApiResponse<NoData>> UpdateAsync(DealerPutDto dto);
       Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
