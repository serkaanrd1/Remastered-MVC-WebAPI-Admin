using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface IDealerRepository : IBaseRepository<Dealer>
    {

        Task<List<Dealer>> GetByNameAsync(string name, params string[] includeList);

        Task<List<Dealer>> GetByCityAsync(string city, params string[] includeList);

        Task<List<Dealer>> GetByNumberAsync(string number, params string[] includeList);

        Task<List<Dealer>> GetByCapactyAsync(int capacty, params string[] includeList);


        Task<Dealer> GetByIdAsync(int dealerId, params string[] includeList);





    }
}
