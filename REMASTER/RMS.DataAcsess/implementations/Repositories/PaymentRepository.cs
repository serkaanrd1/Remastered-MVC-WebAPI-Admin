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
    public class PaymentRepository : BaseRepository<Payment, RemasteredContext>, IPaymentRepository
    {
        public async Task<List<Payment>> GetByAmountAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Amount > min && rms.Amount < max, includeList);
        }

        public async Task<List<Payment>> GetByCustomerAsync(Customer customer, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.Customer == customer, includeList);
        }

        public async Task<List<Payment>> GetByCustomerIdAsync(int customerId, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.CustomerID == customerId, includeList);
        }

        public async Task<List<Payment>> GetByDateAsync(DateTime date, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.PaymentDate == date, includeList);
        }

        public async Task<Payment> GetByIdAsync(int PaymentId, params string[] includeList)
        {
            return await GetAsync(rms => rms.PaymentID == PaymentId, includeList);
        }

        public async Task<List<Payment>> GetByInvoiceIdAsync(int invoiceId, params string[] includeList)
        {
            return await GetAllAsync(rms => rms.InvoiceID == invoiceId, includeList);
        }
    }
}
