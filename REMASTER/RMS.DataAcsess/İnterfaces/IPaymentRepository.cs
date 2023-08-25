using Infrastructure.DataAccess;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.İnterfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<List<Payment>> GetByCustomerIdAsync(int customerId, params string[] includeList);
        Task<List<Payment>> GetByInvoiceIdAsync(int invoiceId, params string[] includeList);
        Task<List<Payment>> GetByAmountAsync(decimal min,decimal max, params string[] includeList);
        Task<List<Payment>> GetByDateAsync(DateTime date, params string[] includeList);
        Task<List<Payment>> GetByCustomerAsync(Customer customer, params string[] includeList);
        Task<Payment> GetByIdAsync(int PaymentId, params string[] includeList);
    }
}



