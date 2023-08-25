using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Customer;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Vehicle;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class VehicleController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public VehicleController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<VehicleItem>>>("/vehicles");

            return View(response.Data);

        }

        [HttpPost]
        public async Task<IActionResult> Save(NewVehicleDto dto, IFormFile productImage)
        {


            if (productImage == null)
                return Json(new { IsSuccess = false, Message = "Araç resmi seçilmelidir" });

            if (!productImage.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Araç resim dosyası seçilmelidir" });

            if (productImage.Length > 1024 * 250)
                return Json(new { IsSuccess = false, Message = "Araç resim büyüklüğü en fazla 250 KB olaiblir" });



            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(productImage.FileName)}";
            var uploadPath = $@"{_webHost.WebRootPath}/adminPanel/productImages/{randomFileName}";

            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await productImage.CopyToAsync(fs);
            }



            var postData = new
            {
                Make = dto.Make,
                Model = dto.Model,


            };

            var response =
              await _apiService.PostData<ResponseBody<VehicleItem>>("/vehicles", JsonSerializer.Serialize(postData));


            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Araç Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Araç Başarıyla Kaydedildi" });


            var errorMessages = string.Empty;


            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Araç Kaydedilemedi <br /> {errorMessages}"
            });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/vehicles/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Araç Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Araç Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetVehicles(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<VehicleItem>>($"/vehicles/{id}");

            return Json(new
            {
                Make = response.Data.Make,
                Model = response.Data.Model,
                VehicleId = response.Data.VehicleID
            });

        }
    }    
}