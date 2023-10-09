using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using ProjectTestApi.Models;
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
        public const string _url = "http://ww2.tuyennhansu.vn/";
        public const string _urlBreadCrumb = "http://ww2.tuyennhansu.vn/web.breadcrumb.asp?id=";
        string notice = "";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            try {
                using (HttpClient httpClient = new HttpClient())
                {
                    var urlContent = _url + "web.trangchu.module.content.asp";
                    string jsonContent = await httpClient.GetStringAsync(urlContent);
                    //var json = (new WebClient()).DownloadString(_url + "web.trangchu.module.content.asp");
                    var listContent = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent);
                    return View(listContent);
                }
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("tin-tuc")]
        public async Task<IActionResult> News()
        {
            const int idpart = 35001;
            var isCheckBreadCrumb = await GetValueBreadCrumb(idpart);
            try
            {
                var obj = await _listNewsModels(idpart);
                var title = await getTitleTopMenu(idpart);
                if (isCheckBreadCrumb != null) {
                    ViewBag.BreadCrumb = isCheckBreadCrumb;
                }
                return View(obj);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        [Route("tuyen-nhan-vien")]
        public async Task<IActionResult> Recruitment(int? page)
        {
            const int idpart = 35004;
            var isCheckBreadCrumb = GetValueBreadCrumb(idpart);
            try
            {
                var obj = await _listRecruitmentModels(idpart);
                if (isCheckBreadCrumb != null)
                {
                    ViewBag.BreadCrumb = isCheckBreadCrumb;
                }

                int pageSize = (int)obj[0].recordsFiltered;
                int pageNumber = page == null || page < 0 ? 1 : page.Value;
                PagedList<ApiModel.DataDetail> lst = new PagedList<ApiModel.DataDetail>(obj[0].data, pageNumber, pageSize);
                return View(lst);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<IActionResult> Intern()
        {
            const int idpart = 35004;
            var isCheckBreadCrumb = GetValueBreadCrumb(idpart);
            try
            {
                var obj = _listNewsModels(idpart);
                if (isCheckBreadCrumb != null)
                {
                    ViewBag.BreadCrumb = isCheckBreadCrumb;
                }
                return View(obj);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("ban-do")]
        public async Task<IActionResult> Map()
        {
            const int idpart = 35014;
            var isCheckBreadCrumb = await GetValueBreadCrumb(idpart);
            try
            {
                if (isCheckBreadCrumb != null)
                {
                    ViewBag.BreadCrumb = isCheckBreadCrumb;
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return View();
        }

        [HttpGet]
        [Route("/dang-nhap")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [Route("/dang-nhap")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var urlApi = "http://ww1.tuyennhansu.vn/userlogin.asp?userid=" + loginViewModel.typeEmailX + "&pass=" + loginViewModel.typePasswordX;
            try
            {
                var json = await ReadJson(urlApi);
                if(json != null)
                {
                    var result = JsonSerializer.Deserialize<List<StatusLoginModel>>(json);
                    return Json(result);
                }
            } 
            catch(Exception e)
            {
                throw;
            }
            return View();
        }

        [HttpGet]
        [Route("tim-cong-viec")]
        public async Task<IActionResult> Search()
        {
            var urlSearch = "http://ww2.tuyennhansu.vn/module.Timboloc.asp";
            try
            {
                var json = await ReadJson(urlSearch);
                if (json != null)
                {
                    var list = JsonSerializer.Deserialize<List<ApiModel>>(json);
                    return View(list[0].data);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [Route("tim-cong-viec")]
        public async Task<IActionResult> Search(SearchViewModel searchViewModel)
        {
            var url = "http://ww2.tuyennhansu.vn/module.timboloc.asp?id=&id1=&id2=";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    if (searchViewModel.id != null && searchViewModel.id2 == null)
                    {
                        var _id = ReplaceSpacesWithPercent20(searchViewModel.id);
                        url = "http://ww2.tuyennhansu.vn/module.timboloc.asp?id=" + _id + "&id1=&id2=";

                    }
                    else if (searchViewModel.id == null && searchViewModel.id2 != null)
                    {
                        var _id2 = ReplaceSpacesWithPercent20(searchViewModel.id2);
                        url = url + _id2;
                    }
                    else if (searchViewModel.id != null && searchViewModel.id2 != null)
                    {
                        var _id = ReplaceSpacesWithPercent20(searchViewModel.id);
                        var _id2 = ReplaceSpacesWithPercent20(searchViewModel.id2);
                        url = "http://ww2.tuyennhansu.vn/module.timboloc.asp?id=" + _id2 + "&id1=&id2=" + _id;
                    }
                    //var json = (new WebClient()).DownloadString(url);
                    string jsonContent = await httpClient.GetStringAsync(url);
                    var list = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent);
                    if (list.Count != 0)
                    {
                        return View(list[0].data);
                    }
                    return View();
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", "Home");
        }
        [Route("/{url}")]
        public async Task<IActionResult> JobDetail(int? id, string url)
        {
            var urlResult = "http://ww2.tuyennhansu.vn/web.all.url.asp?id1="+url;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //var json = (new WebClient()).DownloadString(urlResult);
                    string jsonContent = await httpClient.GetStringAsync(urlResult);

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var list = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent, options);

                    return View(list);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        [Route("/sangprovip")]
        public async Task<IActionResult> Test()
        {
            return View();
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
            //string domainName = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            string json = await ReadJson(_url + "app.menu.dautrang.asp");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var list = JsonSerializer.Deserialize<List<ApiModel>>(json,options);
            foreach(var js in list)
            {
                if(js.idpart == key.ToString())
                {
                    var result = _url+ "module."+js.kieuhienthi+".asp?id="+js.idpart;
                    return result;
                }
            }
            return null;
        }

        private async Task FilterHandle()
        {

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

            string json = await ReadJson(_url + "web.trangchu.module.content.asp");
            var list = JsonSerializer.Deserialize<List<ApiModel>>(json);

            foreach (var js in list)
            {
                result.Add(js);
            }
            return result;
        }

        private async Task<bool> GetNameUrl(string url)
        {
            string json = await ReadJson(_url + "app.menu.dautrang.asp");
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
            var arr = JsonSerializer.Deserialize<List<BreadCrumbModel>>(await ReadJson(_urlBreadCrumb+idPart));
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
        private async Task<ApiModel> getTitleTopMenu(int _idpart)
        {
            var result = new ApiModel();
            try
            {
                using(HttpClient httpClient = new HttpClient())
                {
                    string jsonContent = await httpClient.GetStringAsync("http://ww2.tuyennhansu.vn/app.menu.dautrang.asp");

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
    }
}