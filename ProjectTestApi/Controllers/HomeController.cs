using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using ProjectTestApi.Models;
using ProjectTestApi.Models.Const;
using ProjectTestApi.Models.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;
using X.PagedList;
using X.PagedList.Web.Common;

namespace ProjectTestApi.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public const string _urlBreadCrumb = MyConstanst.SiteName + "web.breadcrumb.asp?id=";
        string notice = "";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [HttpGet]
        [Route("trang-chu")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            try
            {
                string apiHomeContent = MyConstanst.SiteName + "web.trangchu.module.content.asp";
                using (HttpClient client = new HttpClient())
                {
                    string jsonContent = await client.GetStringAsync(apiHomeContent);
                    if (!string.IsNullOrEmpty(jsonContent))
                    {
                        List<ApiHomeContentModel> models = JsonSerializer
                            .Deserialize<List<ApiHomeContentModel>>(jsonContent);
                        return View(models);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json("Error");
        }

        [HttpGet]
        [Route("tuyen-thuc-tap-sinh")]
        public async Task<IActionResult> TuyenThucTapSinh()
        {
            try
            {
                string api = MyConstanst.SiteName + "web.all.url.asp?id1=tuyen-thuc-tap-sinh";
                string contentApi = await new WebClient().DownloadStringTaskAsync(api);

                using(MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contentApi)))
                {
                    if (!string.IsNullOrEmpty(contentApi))
                    {
                        List<WebAllModel> result = await JsonSerializer.DeserializeAsync<List<WebAllModel>>(stream);
                        stream.Close();
                        return View(result);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("tin-tuc")]
        public async Task<IActionResult> TinTuc()
        {
            try
            {
                string api = MyConstanst.SiteName + "web.all.url.asp?id1=tin-tuc";
                string contentApi = await new WebClient().DownloadStringTaskAsync(api);

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contentApi)))
                {
                    if (!string.IsNullOrEmpty(contentApi))
                    {
                        List<WebAllModel> result = await JsonSerializer.DeserializeAsync<List<WebAllModel>>(stream);
                        stream.Close();
                        return View(result);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("/{key}")]
        public async Task<IActionResult> DanhMucTinTuc(string? key)
        {
            try
            {
                string api = MyConstanst.SiteName + "web.all.url.asp?id1=" + key;
                string contentApi = await new WebClient().DownloadStringTaskAsync(api);

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contentApi)))
                {
                    if (!string.IsNullOrEmpty(contentApi))
                    {
                        List<WebAllModel> result = await JsonSerializer.DeserializeAsync<List<WebAllModel>>(stream);
                        stream.Close();
                        ViewData["Title"] = result[0].tieude;
                        return View(result);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json("Error");
        }

        [HttpGet]
        public async Task<IActionResult> NoiDungTinTuc(string? key)
        {
            try
            {
                string api = MyConstanst.SiteName + "web.all.url.asp?id1=" + key;
                string contentApi = await new WebClient().DownloadStringTaskAsync(api);

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contentApi)))
                {
                    if (!string.IsNullOrEmpty(contentApi))
                    {
                        List<WebAllModel> result = await JsonSerializer.DeserializeAsync<List<WebAllModel>>(stream);
                        stream.Close();
                        ViewData["Title"] = result[0].tieude;
                        return View(result);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json("Error");
        }

        [HttpGet]
        public async Task<IActionResult> ChiTietTinTuc(string? keyword)
        {
            try
            {
                string api = MyConstanst.SiteName + "web.all.url.asp?id1="+keyword;
                string contentApi = await new WebClient().DownloadStringTaskAsync(api);

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contentApi)))
                {
                    if (!string.IsNullOrEmpty(contentApi))
                    {
                        List<WebAllModel> result = await JsonSerializer.DeserializeAsync<List<WebAllModel>>(stream);
                        stream.Close();
                        ViewData["Title"] = result[0].tieude;
                        return View(result);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> NoiDungChiTiet(string? keyword)
        {
            try
            {
                string api = MyConstanst.SiteName + "web.all.url.asp?id1=" + keyword;
                string contentApi = await new WebClient().DownloadStringTaskAsync(api);

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contentApi)))
                {
                    if (!string.IsNullOrEmpty(contentApi))
                    {
                        List<WebAllModel> result = await JsonSerializer.DeserializeAsync<List<WebAllModel>>(stream);
                        stream.Close();
                        ViewData["Title"] = result[0].tieude;
                        return View(result);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> Search(string? keyword)
        {
            try
            {
                string api = MyConstanst.SiteName + "web.all.url.asp?id1=" + keyword;
                string contentApi = await new WebClient().DownloadStringTaskAsync(api);

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contentApi)))
                {
                    if (!string.IsNullOrEmpty(contentApi))
                    {
                        List<WebAllModel> result = await JsonSerializer.DeserializeAsync<List<WebAllModel>>(stream);
                        stream.Close();
                        ViewData["Title"] = result[0].tieude;
                        return View(result);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> TimCongViec(string? id, string? id1, string? id2)
        {
            try
            {
                string api = MyConstanst.SiteName + "web.all.url.asp?id1=tim-cong-viec";
               
                using (HttpClient httpClient = new HttpClient())
                {
                    string contentApi = await httpClient.GetStringAsync(api);

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    if (!string.IsNullOrEmpty(contentApi))
                    {
                        List<WebAllModel> result = JsonSerializer.Deserialize<List<WebAllModel>>(contentApi, options);

                        string apiBoLoc = MyConstanst.SiteName + "module."+ result[0].module +".asp?id="+id+"&id2="+ ReplaceSpacesWithPercent20(id2)+ "&pageid=1";

                        string contentBoLoc = await httpClient.GetStringAsync(apiBoLoc);

                        if (!string.IsNullOrEmpty(contentBoLoc))
                        {
                            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contentBoLoc)))
                            {
                                List<ApiModel> myObject = await JsonSerializer.DeserializeAsync<List<ApiModel>>(stream);

                                ViewBag.ResultSearch = myObject;
                                return View(result);
                            }
                        }
                    }                 
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<string> ReadJson(string url)
        {
            try {
                using (HttpClient httpClient = new HttpClient())
                {
                    string jsonContent = await httpClient.GetStringAsync(url);
                    return jsonContent;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private async Task<string> ApiMenuItem(int key)
        {
            string json = await ReadJson(MyConstanst.SiteName + "app.menu.dautrang.asp");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var list = JsonSerializer.Deserialize<List<ApiModel>>(json,options);
            foreach(var js in list)
            {
                if(js.idpart == key.ToString())
                {
                    var result = MyConstanst.SiteName + "module."+js.kieuhienthi+".asp?id="+js.idpart;
                    return result;
                }
            }
            return null;
        }

        private async Task<List<ApiModel>> _listNewsModels(int key)
        {
            string json = await ReadJson(
                await ApiMenuItem(key));
            return JsonSerializer.Deserialize<List<ApiModel>>(json); ;
        }

        private async Task<List<ApiModel>> _listRecruitmentModels(int key)
        {
            string json = await ReadJson(
                await ApiMenuItem(key));
            return JsonSerializer.Deserialize<List<ApiModel>>(json); ;
        }

        private async Task<List<ApiModel>> _listInternModels(int key)
        {
            string json = await ReadJson(
                await ApiMenuItem(key));
            return JsonSerializer.Deserialize<List<ApiModel>>(json); ;
        }
        private async Task<List<ApiModel>> GetHomeContent()
        {
            List<ApiModel> result = new List<ApiModel>();

            string json = await ReadJson(MyConstanst.SiteName + "web.trangchu.module.content.asp");
            var list = JsonSerializer.Deserialize<List<ApiModel>>(json);

            foreach (var js in list)
            {
                result.Add(js);
            }
            return result;
        }

        private async Task<bool> GetNameUrl(string url)
        {
            string json = await ReadJson(MyConstanst.SiteName + "app.menu.dautrang.asp");
            var list = JsonSerializer.Deserialize<List<ApiModel>>(json);
            foreach(var item in list)
            {
                if(item.url == url)
                {
                    return true;
                }
            }
            return false;
        }
        public bool GetHeaders(string url)
        {
            HttpStatusCode result = default(HttpStatusCode);

            var request = HttpWebRequest.Create(url);
            request.Method = "HEAD";
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response != null)
                {
                    response.Close();
                    return true;
                }
            }
            return false;
        }
        private async Task<List<BreadCrumbModel>> GetValueBreadCrumb(int idPart)
        {
            List<BreadCrumbModel> arr = JsonSerializer.Deserialize<List<BreadCrumbModel>>(await ReadJson(_urlBreadCrumb+idPart));
            if(arr != null)
            {
                return arr;
            }
            return null;
        }

        private string ReplaceSpacesWithPercent20(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                if (c == ' ')
                {
                    result.Append("%20");
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
        private async Task<ApiModel> GetTitleTopMenu(int _idpart)
        {
            var result = new ApiModel();
            try
            {
                using(HttpClient httpClient = new HttpClient())
                {
                    string jsonContent = await httpClient.GetStringAsync(MyConstanst.SiteName +"app.menu.dautrang.asp");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true 
                    };
                    List<ApiModel> lstObj = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent, options);

                    var item = lstObj
                        .Where(item => item.idpart == _idpart.ToString())
                        .FirstOrDefault();

                    if(item != null)
                    {
                        result = item;
                        return result;
                    }
                }
            }catch(Exception ex)
            {
                throw;
            }
            return null; ;
        }

        public async Task<List<ApiModel>> GetInfoContent(string? url)
        {
            List<ApiModel> apiModels = new List<ApiModel>();
            var webAllUrlApi = MyConstanst.SiteName+"web.all.url.asp?id1=" + url;

            using (HttpClient httpClient = new HttpClient())
            {
                string jsonContent = await httpClient.GetStringAsync(webAllUrlApi);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var list = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent, options);

                apiModels = list;
            }

            return apiModels;
        }

        public async Task<List<ApiModel>> GetBoLoc(string? id)
        {
            List<ApiModel> apiModels = new List<ApiModel>();
            var webBoLocApi = MyConstanst.SiteName+"web.boloc.asp?id="+id;

            using (HttpClient httpClient = new HttpClient())
            {
                string jsonContent = await httpClient.GetStringAsync(webBoLocApi);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var list = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent, options);
                apiModels = list;
            }
            return apiModels;
        }

        public async Task<List<ApiModel>> GetContent(string? id,string? tenham)
        {
            List<ApiModel> apiModels = new List<ApiModel>();
            var webApiContent = MyConstanst.SiteName+"module."+tenham+".asp?id=" + id;
            using(HttpClient httpClient = new HttpClient())
            {
                string jsonContent = await httpClient.GetStringAsync(webApiContent);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var list = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent, options);
                apiModels = list;
            }
            return apiModels;
        }
    }
}