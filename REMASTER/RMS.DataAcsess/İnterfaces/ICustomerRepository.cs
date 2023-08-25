using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<List<Customer>> GetByPhoneAsync(string phone, params string[] includeList);
        Task<List<Customer>> GetByFirstNameAsync(string firstName, params string[] includeList);
        Task<List<Customer>> GetByLastNameAsync(string lastName, params string[] includeList);
        Task<List<Customer>> GetByMailAsync(string mail, params string[] includeList);

        Task<Customer> GetByIdAsync(int customerId, params string[] includeList);




    }
}
