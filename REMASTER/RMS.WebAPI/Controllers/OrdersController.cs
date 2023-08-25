using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Business.İnterfaces;
using RMS.Model.Dtos.Payment;
using WS.WebAPI.Controllers;
using RMS.Business.İmplementations;
using RMS.Model.Dtos.Order;

namespace RMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrderBs _orderBs;

        public OrdersController(IOrderBs orderBs)
        {
            _orderBs = orderBs;
        }





        [HttpGet]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> GetAllTechnicians()
        {
            var response = await _orderBs.GetOrdersAsync();

            return SendResponse(response);

        }



        [HttpGet("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _orderBs.GetByIdAsync(id);

            return SendResponse(response);
        }

        [HttpPost]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderPostDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> SaveNewVehicle([FromBody] OrderPostDto dto)
        {
            var response = await _orderBs.InsertAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = response.Data.OrderID }, response.Data);
        }

        [HttpPut]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderPutDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> UpdateProduct([FromBody] OrderPutDto dto)
        {
            var response = await _orderBs.UpdateAsync(dto);

            return SendResponse(response);
        }
        [HttpDelete("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderPutDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var response = await _orderBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}
