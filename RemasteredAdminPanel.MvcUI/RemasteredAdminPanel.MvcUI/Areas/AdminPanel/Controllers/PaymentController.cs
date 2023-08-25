using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Payment;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Service;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class PaymentController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public PaymentController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<PaymentItem>>>("/payments");

            return View(response.Data);

        }



        [HttpPost]
        public async Task<IActionResult> Save(NewPaymentDto dto)
        {
            try
            {
                var postData = new
                {
                    CustomerId = dto.CustomerID,
                    Amount = dto.Amount,
                    InvoiceId = dto.InvoiceID
                };

                var response = await _apiService.PostData<ResponseBody<PaymentItem>>("/services", JsonSerializer.Serialize(postData));

                if (response.StatusCode == 201)
                    return Json(new { IsSuccess = true, Message = "Payment Başarıyla Kaydedildi" });

                if (response.ErrorMessages == null)
                    return Json(new { IsSuccess = false, Message = "Bir hata oluştu ancak hata mesajı alınamadı." });

                var errorMessages = string.Join("<br />", response.ErrorMessages);

                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Payment Kaydedilemedi <br /> {errorMessages}"
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
              await _apiService.DeleteData($"/payments/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Payment Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Payment Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetPayment(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<PaymentItem>>($"/services/{id}");

            return Json(new
            {
                CustomerId = response.Data.CustomerID,
                Amount = response.Data.Amount,
                PaymentId = response.Data.PaymentID
            });

        }
    }
}
