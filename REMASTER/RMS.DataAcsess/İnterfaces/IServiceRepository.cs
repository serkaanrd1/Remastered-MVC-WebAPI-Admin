using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface IServiceRepository : IBaseRepository<Service>
    {
        Task<List<Service>> GetByNameAsync(string name, params string[] includeList);
        Task<List<Service>> GetByDescAsync(string desc, params string[] includeList);
        Task<List<Service>> GetByPriceAsync(decimal min,decimal max, params string[] includeList);
        Task<Service> GetByIdAsync(int serviceId, params string[] includeList);
    }
}
