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
    public class InvoiceRepository : BaseRepository<Invoice, RemasteredContext>, IInvoiceRepository
    {
        public async Task<List<Invoice>> GetByAmountAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.TotalAmount > min && rms.TotalAmount < max, includeList);
        }

        public async Task<List<Invoice>> GetByCustomerAsync(Customer customer, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Customer == customer, includeList);
        }

        public async Task<List<Invoice>> GetByCustomerIdAsync(int customerId, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.CustomerID == customerId, includeList);
        }

        public async  Task<List<Invoice>> GetByDateAsync(DateTime date, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.InvoiceDate == date, includeList);
        }

        public async Task<Invoice> GetByIdAsync(int invoiceId, params string[] includeList)
        {
            return await GetAsync(rms => rms.InvoiceID == invoiceId, includeList);
        }

     
    }
}
