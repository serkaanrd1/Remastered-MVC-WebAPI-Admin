using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        Task<List<Invoice>> GetByCustomerIdAsync(int customerId, params string[] includeList);
        Task<List<Invoice>> GetByAmountAsync(decimal min, decimal max, params string[] includeList);
        Task<List<Invoice>> GetByDateAsync(DateTime date, params string[] includeList);
        Task<List<Invoice>> GetByCustomerAsync(Customer customer, params string[] includeList);
        Task<Invoice> GetByIdAsync(int invoiceId, params string[] includeList);
    }
}



