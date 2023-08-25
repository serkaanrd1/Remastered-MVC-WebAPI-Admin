
using Microsoft.AspNetCore.Mvc;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.Dtos;
using System.Text.Json;

namespace RemasteredPanel.MvcUI.Areas.AdminPanel.Controllers
{
  [Area("AdminPanel")]
  public class AuthController : Controller
  {
    private readonly IHttpApiService _apiService;

    public AuthController(IHttpApiService apiService)
    {
      _apiService = apiService;
    }

    [HttpGet]
    public IActionResult LogIn()
    {
      return View();
    }

        //[HttpPost]
        //public async Task<IActionResult> LogIn(LogInDto dto)
        //{
        //  // servisle habeleşecek ilgili endpointten böyle bir kullanıcı var mı diye kontrol ettirecek
        //  // SERVİSDEN GELEN YANITA BAKACAK 
        //  // client tarayıcısına, oradaki ajax çağrılan yere bir yanıt dönecek

        //  using (HttpClient client = new HttpClient())
        //  {
        //    client.BaseAddress = new Uri("http://localhost:5083/api");

        //    var responseMessage = await client.GetAsync($"{client.BaseAddress}/auth/login?userName={dto.UserName}&password={dto.Password}");

        //    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

        //    var response = JsonSerializer.Deserialize<ResponseBody<AdminPanelUserItem>>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        //    if (responseMessage.IsSuccessStatusCode)
        //    {

        //      HttpContext.Session.SetString("ActiveAdminPanelUser", JsonSerializer.Serialize(response.Data));

        //      return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
        //    }
        //    else
        //    {
        //      return Json(new {IsSuccess=false,Messages=response.ErrorMessages });
        //    }
        //  }


        //}

        [HttpPost]
    public async Task<IActionResult> LogIn(LogInDto dto)
    {
      string endPoint = $"/auth/login?userName={dto.UserName}&password={dto.Password}";

      var response = 
        await _apiService.GetData<ResponseBody<AdminPanelUserItem>>(endPoint);

      if (response.StatusCode == 200)
      {
        HttpContext.Session.SetString("ActiveAdminPanelUser", JsonSerializer.Serialize(response.Data));

        return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
      }
      else
      {
        return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
      }
    }
  }
}
