using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Customer;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.Dtos;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class CustomerController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public CustomerController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<CustomerItem>>>("/customers");

            return View(response.Data);

        }



        [HttpPost]
        public async Task<IActionResult> Save(NewCustomerDto dto)
        {
            try
            {
                var postData = new
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };

                var response = await _apiService.PostData<ResponseBody<CustomerItem>>("/customers", JsonSerializer.Serialize(postData));

                if (response.StatusCode == 201)
                    return Json(new { IsSuccess = true, Message = "Müşteri Başarıyla Kaydedildi" });

                if (response.ErrorMessages == null)
                    return Json(new { IsSuccess = true, Message = "Müşteri Başarıyla Kaydedildi" });

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
              await _apiService.DeleteData($"/customers/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Kategori Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Kategori Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<CustomerItem>>($"/customers/{id}");

            return Json(new
            {
                FirstName = response.Data.FirstName,
                LastName = response.Data.LastName,
                CustomerId = response.Data.CustomerID
            });

        }
    }
}
