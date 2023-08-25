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
    public class OrderRepository : BaseRepository<Order, RemasteredContext>, IOrderRepository
    {
        public async Task<List<Order>> GetByAmountAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.TotalAmount > min && rms.TotalAmount < max, includeList);
        }

        public async  Task<List<Order>> GetByCustomerAsync(Customer customer, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Customer == customer, includeList);
        }

        public async Task<List<Order>> GetByCustomerIdAsync(int customerId, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.CustomerID == customerId, includeList);
        }

        public async Task<List<Order>> GetByDateAsync(DateTime date, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.OrderDate == date, includeList);
        }

        public async Task<Order> GetByIdAsync(int OrderId, params string[] includeList)
        {
            return await GetAsync(rms => rms.OrderID == OrderId, includeList);
        }
    }
}
