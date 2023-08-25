using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.Customer;
using RMS.Model.Dtos.Dealer;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;

namespace RMS.Business.İmplementations
{
    public class DealerBs : IDealerBs
    {

        private readonly IDealerRepository _repo;
        private readonly IMapper _mapper;

        public DealerBs(IDealerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }






        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            throw new BadRequestException("id pozitif bir değer olmalıdır");


            var entity =await _repo.GetByIdAsync(id);
            entity.IsActive = false;

            _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<DealerGetDto>> GetByIdAsync(int dealerId, params string[] includeList)
        {
           
                if (dealerId <= 0)
            throw new BadRequestException("id pozitif bir değer olmalıdır");

            var dealer = await _repo.GetByIdAsync(dealerId, includeList);

                if (dealer == null)
            throw new BadRequestException("bu id li ürün bulunamadı");

            var dto = _mapper.Map<DealerGetDto>(dealer);

                return ApiResponse<DealerGetDto>.Success(StatusCodes.Status200OK, dto);
            
        }

        public async Task<ApiResponse<List<DealerGetDto>>> GetDealersAsync(params string[] includeList)
        {
                var dealers = await _repo.GetAllAsync(p => p.IsActive==true,includeList: includeList);


                if (dealers.Count > 0)
                {
                    var returnList = _mapper.Map<List<DealerGetDto>>(dealers);

                    return ApiResponse<List<DealerGetDto>>.Success(StatusCodes.Status200OK, returnList);
                }

            throw new BadRequestException("kaynak bulunamadı");

        }

        public async Task<ApiResponse<Dealer>> InsertAsync(DealerPostDto dto)
        {
            if (dto.DealerName.Length < 2)
            throw new BadRequestException("customer adı en az 2 karakterden oluşmalıdır");


            if (dto.DealerCity.Length < 3)
            throw new BadRequestException("şehir  3 karakterden büyük bir değer olmalıdır");


            var entity =  _mapper.Map<Dealer>(dto);
            var insertedDealer = await _repo.InsertAsync(entity);
            entity.IsActive = true;

            return ApiResponse<Dealer>.Success(StatusCodes.Status201Created, insertedDealer);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(DealerPutDto dto)
        {
              if (dto.DealerID <= 0)
                {

                    throw new BadRequestException("id pozitif bir değer olmalıdır");
                }

                if (dto.DealerName.Length < 2)
                {

                    throw new BadRequestException("dealer adı en az 2 karakterden oluşmalıdır");
                }

                if (dto.DealerCity.Length < 2)
                {

                    throw new BadRequestException("şehir adı  2 den uzun bir değer olmalıdır");
                }




                var entity =  _mapper.Map<Dealer>(dto);

                _repo.UpdateAsync(entity);

                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
           
        }
    }
}
