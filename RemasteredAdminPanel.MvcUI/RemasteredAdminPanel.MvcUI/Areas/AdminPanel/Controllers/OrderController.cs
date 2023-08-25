using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Customer;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Order;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class OrderController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public OrderController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<OrderItem>>>("/orders");

            return View(response.Data);

        }



        [HttpPost]
        public async Task<IActionResult> Save(NewOrderDto dto)
        {
            try
            {
                var postData = new
                {
                    CustomerId = dto.CustomerID,
                    TotalAmount = dto.TotalAmount
                };

                var response = await _apiService.PostData<ResponseBody<OrderItem>>("/orders", JsonSerializer.Serialize(postData));

                if (response.StatusCode == 201)
                    return Json(new { IsSuccess = true, Message = "Sipariş Başarıyla Kaydedildi" });

                if (response.ErrorMessages == null)
                    return Json(new { IsSuccess = true, Message = "Sipariş Başarıyla Kaydedildi." });

                var errorMessages = string.Join("<br />", response.ErrorMessages);

                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Müşteri Kaydedilemedi <br /> {errorMessages}"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Bir hata oluştu: {ex.Message}"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/orders/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Sipariş Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Sipariş Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<OrderItem>>($"/orders/{id}");

            return Json(new
            {
                CustomerId = response.Data.CustomerID,
                TotalAmount = response.Data.TotalAmount,
            });

        }
    }
}
