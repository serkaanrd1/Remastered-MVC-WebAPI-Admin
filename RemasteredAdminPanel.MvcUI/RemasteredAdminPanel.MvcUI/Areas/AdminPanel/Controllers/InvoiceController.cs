using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Invoice;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Issue;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class InvoiceController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public InvoiceController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<InvoiceItem>>>("/invoices");

            return View(response.Data);

        }



        [HttpPost]
        public async Task<IActionResult> Save(NewInvoiceDto dto)
        {
            try
            {
                var postData = new
                {
                    CustomerId = dto.CustomerID,
                    TotalAmount = dto.TotalAmount
                };

                var response = await _apiService.PostData<ResponseBody<InvoiceItem>>("/invoices", JsonSerializer.Serialize(postData));

                if (response.StatusCode == 201)
                    return Json(new { IsSuccess = true, Message = "Invoices Başarıyla Kaydedildi" });

                if (response.ErrorMessages == null)
                    return Json(new { IsSuccess = false, Message = "Bir hata oluştu ancak hata mesajı alınamadı." });

                var errorMessages = string.Join("<br />", response.ErrorMessages);

                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Invoices Kaydedilemedi <br /> {errorMessages}"
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
              await _apiService.DeleteData($"/invoices/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Invoice Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Invoice Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<InvoiceItem>>($"/invoice/{id}");

            return Json(new
            {
                CustomerId = response.Data.CustomerID,
                TotalAmount = response.Data.TotalAmount,
                InvoiceId = response.Data.InvoiceID
            });

        }
    }
}
