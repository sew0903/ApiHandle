using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectTestApi.Models;
using ProjectTestApi.Models.Const;

namespace ProjectTestApi.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UserManager(string? url)
        {
            try
            {
                using(HttpClient  client = new HttpClient())
                {
                    string apiUrl = MyConstanst.SiteName 
                        + "web.all.url.asp?id1=" 
                        + url;
                    string jsonResult = await client.GetStringAsync(apiUrl);
                    if (!string.IsNullOrEmpty(jsonResult))
                    {
                        List<Member1Model> result = JsonConvert.DeserializeObject<List<Member1Model>>(jsonResult);
                        return View(result);
                    }
                }
            }catch(Exception ex)
            {
                throw;
            }
            return View();
        }
    }
}
