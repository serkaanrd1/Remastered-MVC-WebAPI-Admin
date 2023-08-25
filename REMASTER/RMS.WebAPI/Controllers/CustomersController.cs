using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Business.İnterfaces;
using RMS.Model.Dtos.Customer;
using WS.WebAPI.Controllers;

namespace RMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICustomerBs _customerBs;
        public CustomersController(ICustomerBs customerBs)
        {
            _customerBs = customerBs;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {

            var response =await _customerBs.GetCustomersAsync();

            return SendResponse(response);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _customerBs.GetByIdAsync(id);

            return SendResponse(response);

        }


        [HttpPost]
        public async Task<ActionResult>SaveNewCarsoftware([FromBody] CustomerPostDto dto)
        {
            var response = await _customerBs.InsertAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = response.Data.CustomerID }, response.Data);
        }




        [HttpPut]
        public async Task<ActionResult>UpdateCarsoftware([FromBody] CustomerPutDto dto)
        {
            var response =await _customerBs.UpdateAsync(dto);

            return SendResponse(response);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarsoftware(int id)
        {
            var response = await _customerBs.DeleteAsync(id);

            return SendResponse(response);
        }


















    }
}
