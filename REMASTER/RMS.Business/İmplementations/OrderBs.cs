using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.Order;
using RMS.Model.Dtos.Payment;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;

namespace RMS.Business.İmplementations
{
    public class OrderBs : IOrderBs
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        public OrderBs(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("id pozitif bir değer olmalıdır");
            }
            var entity = await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<OrderGetDto>> GetByIdAsync(int orderId, params string[] includeList)
        {
            if (orderId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var order = await _repo.GetByIdAsync(orderId, includeList);

            if (order == null)
                throw new NotFoundException("bu id li sipariş kayıtı bulunamadı");

            var dto = _mapper.Map<OrderGetDto>(order);

            return ApiResponse<OrderGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersAsync(params string[] includeList)
        {
            var orders = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (orders.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersByAmountAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min değer max değerden büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("fiyatlar pozitif değer olmalıdır");


            var orders = await _repo.GetByAmountAsync(min, max, includeList);

            if (orders.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersByCustomersAsync(int customerId, params string[] includeList)
        {
            if (customerId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var orders = await _repo.GetByCustomerIdAsync(customerId, includeList);

            if (orders.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersByDateAsync(DateTime orderDate, params string[] includeList)
        {
            var orders = await _repo.GetByDateAsync(orderDate, includeList);

            if (orders.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public  async Task<ApiResponse<Order>> InsertAsync(OrderPostDto dto)
        {
            var entity = _mapper.Map<Order>(dto);
            entity.IsActive = true;



            var insertedProduct = await _repo.InsertAsync(entity);

            return ApiResponse<Order>.Success(StatusCodes.Status201Created, insertedProduct);
        }

        public async  Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto dto)
        {
            if (dto.OrderID <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");


            var entity = _mapper.Map<Order>(dto);
            entity.IsActive = true;


            await _repo.UpdateAsync(entity);


            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
