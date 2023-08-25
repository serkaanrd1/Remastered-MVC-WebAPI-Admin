using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.Invoice;
using RMS.Model.Dtos.Issue;
using RMS.Model.Dtos.Order;
using RMS.Model.Dtos.Payment;
using RMS.Model.Entities;

using WS.Business.CustomExceptions;

namespace RMS.Business.İmplementations
{
    public class InvoiceBs : IInvoiceBs
    {
        private readonly IInvoiceRepository _repo;
        private readonly IMapper _mapper;
        public InvoiceBs(IInvoiceRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<InvoiceGetDto>> GetByIdAsync(int invoiceId, params string[] includeList)
        {

            if (invoiceId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var invoice = await _repo.GetByIdAsync(invoiceId, includeList);

            if (invoice == null)
                throw new NotFoundException("bu id li fatura kaydı bulunamadı");

            var dto = _mapper.Map<InvoiceGetDto>(invoice);

            return ApiResponse<InvoiceGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<InvoiceGetDto>>> GetInvoicesAsync(params string[] includeList)
        {
            var invoices = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (invoices.Count > 0)
            {
                var returnList = _mapper.Map<List<InvoiceGetDto>>(invoices);

                return ApiResponse<List<InvoiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<InvoiceGetDto>>> GetInvoicesByAmountAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min değer max değerden büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("fiyatlar pozitif değer olmalıdır");


            var invoices = await _repo.GetByAmountAsync(min, max, includeList);

            if (invoices.Count > 0)
            {
                var returnList = _mapper.Map<List<InvoiceGetDto>>(invoices);

                return ApiResponse<List<InvoiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<InvoiceGetDto>>> GetInvoicesByCustomersAsync(int customerId, params string[] includeList)
        {
            if (customerId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var invoices = await _repo.GetByCustomerIdAsync(customerId, includeList);

            if (invoices.Count > 0)
            {
                var returnList = _mapper.Map<List<InvoiceGetDto>>(invoices);

                return ApiResponse<List<InvoiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<InvoiceGetDto>>> GetInvoicesByDateAsync(DateTime date, params string[] includeList)
        {
            var invoices = await _repo.GetByDateAsync(date, includeList);

            if (invoices.Count > 0)
            {
                var returnList = _mapper.Map<List<InvoiceGetDto>>(invoices);

                return ApiResponse<List<InvoiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Invoice>> InsertAsync(InvoicePostDto dto)
        {
            

            var entity = _mapper.Map<Invoice>(dto);
            entity.IsActive = true;



            var insertedProduct = await _repo.InsertAsync(entity);

            return ApiResponse<Invoice>.Success(StatusCodes.Status201Created, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(InvoicePutDto dto)
        {
            if (dto.InvoiceID <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");


            var entity = _mapper.Map<Invoice>(dto);
            entity.IsActive = true;


            await _repo.UpdateAsync(entity);


            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
