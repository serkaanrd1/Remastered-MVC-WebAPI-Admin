using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Customer;

namespace RMS.Business.İnterfaces
{
    public interface ICustomerBs 
    {


       Task<ApiResponse<List<CustomerGetDto>>> GetCustomersAsync(params string[] includeList);
       Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int customerId, params string[] includeList);
       Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto);
       Task<ApiResponse<NoData>>UpdateAsync(CustomerPutDto dto);
       Task<ApiResponse<NoData>> DeleteAsync(int id);



      






    }
}
