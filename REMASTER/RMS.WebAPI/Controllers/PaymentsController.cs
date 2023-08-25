using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Business.İnterfaces;
using RMS.Model.Dtos.Service;
using WS.WebAPI.Controllers;
using RMS.Model.Dtos.Payment;

namespace RMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseController
    {
        private readonly IPaymentBs _paymentBs;

        public PaymentsController(IPaymentBs paymentBs)
        {
            _paymentBs = paymentBs;
        }





        [HttpGet]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<PaymentGetDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> GetAllTechnicians()
        {
            var response = await _paymentBs.GetPaymentsPerformedAsync();

            return SendResponse(response);

        }



        [HttpGet("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<PaymentGetDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _paymentBs.GetByIdAsync(id);

            return SendResponse(response);
        }

        [HttpPost]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<PaymentPostDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> SaveNewVehicle([FromBody] PaymentPostDto dto)
        {
            var response = await _paymentBs.InsertAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = response.Data.PaymentID }, response.Data);
        }

        [HttpPut]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<PaymentPutDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> UpdateProduct([FromBody] PaymentPutDto dto)
        {
            var response = await _paymentBs.UpdateAsync(dto);

            return SendResponse(response);
        }
        [HttpDelete("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<PaymentPutDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var response = await _paymentBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}
