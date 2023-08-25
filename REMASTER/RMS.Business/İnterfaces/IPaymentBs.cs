using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Payment;

namespace RMS.Business.İnterfaces
{
    public interface IPaymentBs
    {
        Task<ApiResponse<List<PaymentGetDto>>> GetPaymentsPerformedAsync(params string[] includeList);
        Task<ApiResponse<List<PaymentGetDto>>> GetPaymentsByDateAsync(DateTime paymentdate, params string[] includeList);
        Task<ApiResponse<List<PaymentGetDto>>> GetPaymentsByAmountAsync(decimal min,decimal max, params string[] includeList);
        Task<ApiResponse<List<PaymentGetDto>>> GetPaymentsByInvoiceAsync(int invoiceId, params string[] includeList);
        Task<ApiResponse<List<PaymentGetDto>>> GetServicesByCustomersAsync(int customerId, params string[] includeList);
        Task<ApiResponse<PaymentGetDto>> GetByIdAsync(int paymentId, params string[] includeList);

        Task<ApiResponse<Payment>> InsertAsync(PaymentPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(PaymentPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}


