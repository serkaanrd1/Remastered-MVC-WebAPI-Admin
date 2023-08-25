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
    public class DealerRepository : BaseRepository<Dealer, RemasteredContext>, IDealerRepository
    {
        public async Task<List<Dealer>> GetByCapactyAsync(int capacty, params string[] includeList)
        {
            return await GetAllAsync(dlr => dlr.DealerCapacty == capacty, includeList);
        }

        public async Task<List<Dealer>> GetByCityAsync(string city, params string[] includeList)
        {
            return await GetAllAsync(dlr => dlr.DealerCity == city, includeList);
        }

        public  async Task<Dealer> GetByIdAsync(int dealerId, params string[] includeList)
        {
            return await GetAsync(dlr => dlr.DealerID == dealerId, includeList);
        }

        public async Task<List<Dealer>> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(dlr => dlr.DealerName == name, includeList);
        }

        public  async Task<List<Dealer>> GetByNumberAsync(string number, params string[] includeList)
        {
            return  await GetAllAsync(dlr => dlr.DealerNumber == number, includeList);
        }
    }
}
