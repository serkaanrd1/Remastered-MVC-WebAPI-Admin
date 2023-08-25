using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Dtos.ServicePerformed;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Invoice;

namespace RMS.Business.İnterfaces
{
    public interface IInvoiceBs
    {
        Task<ApiResponse<List<InvoiceGetDto>>> GetInvoicesAsync(params string[] includeList);
        Task<ApiResponse<List<InvoiceGetDto>>> GetInvoicesByDateAsync(DateTime date, params string[] includeList);
        Task<ApiResponse<List<InvoiceGetDto>>> GetInvoicesByAmountAsync(decimal min,decimal max , params string[] includeList);
        Task<ApiResponse<List<InvoiceGetDto>>> GetInvoicesByCustomersAsync(int customerId, params string[] includeList);
        Task<ApiResponse<InvoiceGetDto>> GetByIdAsync(int invoiceId, params string[] includeList);

        Task<ApiResponse<Invoice>> InsertAsync(InvoicePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(InvoicePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

