using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using RMS.Model.Dtos.Payment;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Model.Dtos.Order;

namespace RMS.Business.İnterfaces
{
    public interface IOrderBs
    {
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersAsync(params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersByDateAsync(DateTime orderDate, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersByAmountAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersByCustomersAsync(int customerId, params string[] includeList);
        Task<ApiResponse<OrderGetDto>> GetByIdAsync(int orderId, params string[] includeList);

        Task<ApiResponse<Order>> InsertAsync(OrderPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}


