using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetByCustomerIdAsync(int customerId, params string[] includeList);
        Task<List<Order>> GetByAmountAsync(decimal min, decimal max, params string[] includeList);
        Task<List<Order>> GetByDateAsync(DateTime date, params string[] includeList);
        Task<List<Order>> GetByCustomerAsync(Customer customer, params string[] includeList);
        Task<Order> GetByIdAsync(int OrderId, params string[] includeList);
    }
}



