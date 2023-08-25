using Infrastructure.DataAccess.EF;
using RMS.DataAcsess.implementations.EF.Context;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RMS.DataAcsess.implementations.Repositories
{
    public class ServiceRepository : BaseRepository<Service, RemasteredContext>, IServiceRepository
    {
        public async Task<List<Service>> GetByDescAsync(string desc, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Description == desc, includeList);
        }

        public async Task<Service> GetByIdAsync(int serviceId, params string[] includeList)
        {
            return await GetAsync(rms => rms.ServiceID == serviceId, includeList);
        }

        public async Task<List<Service>> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.ServiceName == name, includeList);
        }

        public async Task<List<Service>> GetByPriceAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Price > min && rms.Price < max, includeList);
        }
    }
}
