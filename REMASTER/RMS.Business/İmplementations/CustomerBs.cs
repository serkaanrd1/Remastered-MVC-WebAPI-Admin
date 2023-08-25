using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.Customer;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;

namespace RMS.Business.İmplementations
{
    public class CustomerBs : ICustomerBs
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerBs(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }



        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");


            var entity = await _repo.GetByIdAsync(id);
            entity.IsActive = false;

            _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int customerId, params string[] includeList)
        {

            if (customerId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var customer = await _repo.GetByIdAsync(customerId, includeList);

            if (customer == null)
                throw new BadRequestException("bu id li müşteri bulunamadı");

            var dto = _mapper.Map<CustomerGetDto>(customer);

            return ApiResponse<CustomerGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersAsync(params string[] includeList)
        {
            var customers = await _repo.GetAllAsync(p => p.IsActive==true, includeList: includeList);


            if (customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);

                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new BadRequestException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto)
        {
            if (dto.FirstName.Length < 2)
                return ApiResponse<Customer>.Fail(StatusCodes.Status400BadRequest, "müşteri adı en az 2 karakterden oluşmalıdır");

            if (dto.LastName.Length < 2)
                return ApiResponse<Customer>.Fail(StatusCodes.Status400BadRequest, "müşteri soyadı  2 karakterden büyük bir değer olmalıdır");


            var entity = _mapper.Map<Customer>(dto);
            entity.IsActive = true;

            var insertedCustomer = await _repo.InsertAsync(entity);

            return ApiResponse<Customer>.Success(StatusCodes.Status201Created, insertedCustomer);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto dto)
        {
            if (dto.CustomerID <= 0)
            {

                throw new BadRequestException("id pozitif bir değer olmalıdır");
            }

            if (dto.FirstName.Length < 2)
            {

                throw new BadRequestException("müşteri adı en az 2 karakterden oluşmalıdır");
            }

            if (dto.LastName.Length < 2)
            {

                throw new BadRequestException("müşteri soyadı  2 den uzun bir değer olmalıdır");
            }



            var entity = _mapper.Map<Customer>(dto);

            _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

    }
}


     

