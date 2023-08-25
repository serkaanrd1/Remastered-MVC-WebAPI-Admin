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
    public class IssueRepository : BaseRepository<Issue, RemasteredContext>, IIssueRepository
    {
        public async Task<List<Issue>> GetByCustomerAsync(Customer customer, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Customer == customer, includeList);
        }

        public async Task<List<Issue>> GetByCustomerIdAsync(int customerId, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.CustomerID == customerId, includeList);
        }

        public async Task<List<Issue>> GetByDescAsync(string desc, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Description == desc, includeList);
        }

        public  async Task<Issue> GetByIdAsync(int issueId, params string[] includeList)
        {
            return await GetAsync(rms => rms.IssueID == issueId, includeList);
        }

        public async Task<List<Issue>> GetByVehicleIdAsync(int vehicleId, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.VehicleID == vehicleId, includeList);
        }
    }
}
