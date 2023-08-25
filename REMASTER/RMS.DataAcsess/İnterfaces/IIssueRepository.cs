using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface IIssueRepository : IBaseRepository<Issue>
    {
        Task<List<Issue>> GetByCustomerIdAsync(int customerId, params string[] includeList);
        Task<List<Issue>> GetByVehicleIdAsync(int vehicleId, params string[] includeList);
        Task<List<Issue>> GetByDescAsync(string desc ,   params string[] includeList);
        Task<List<Issue>> GetByCustomerAsync(Customer customer, params string[] includeList);
        Task<Issue> GetByIdAsync(int issueId, params string[] includeList);
    }
}


