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
    public class CustomerRepository : BaseRepository<Customer, RemasteredContext>, ICustomerRepository
    {
        public async Task<List<Customer>> GetByFirstNameAsync(string firstName, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.FirstName == firstName, includeList);
        }

        public  async Task<Customer> GetByIdAsync(int customerId, params string[] includeList)
        {
            return await GetAsync(rms => rms.CustomerID == customerId, includeList);
        }

        public async Task<List<Customer>> GetByLastNameAsync(string lastName, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.LastName == lastName, includeList);
        }

        public async Task<List<Customer>> GetByMailAsync(string mail, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Email == mail, includeList);
        }

        public async Task<List<Customer>> GetByPhoneAsync(string phone, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.PhoneNumber == phone, includeList);
        }
    }
}
