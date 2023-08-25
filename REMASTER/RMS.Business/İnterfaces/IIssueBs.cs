using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Dtos.Payment;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Issue;

namespace RMS.Business.İnterfaces
{
    public interface IIssueBs
    {
        Task<ApiResponse<List<IssueGetDto>>> GetIssuesPerformedAsync(params string[] includeList);
        Task<ApiResponse<List<IssueGetDto>>> GetIssuesByDescAsync(string desc,  params string[] includeList);
        Task<ApiResponse<List<IssueGetDto>>> GetIssuesByVehicleAsync(int vehicleId, params string[] includeList);
        Task<ApiResponse<List<IssueGetDto>>> GetIssuesByCustomersAsync(int customerId, params string[] includeList);
        Task<ApiResponse<IssueGetDto>> GetByIdAsync(int issueId, params string[] includeList);

        Task<ApiResponse<Issue>> InsertAsync(IssuePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(IssuePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

