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

        public async Task<IActionResult> Index()
        {
            try {
                using (HttpClient httpClient = new HttpClient())
                {
                    var urlContent = MyConstanst.SiteName + "web.trangchu.module.content.asp";
                    string jsonContent = await httpClient.GetStringAsync(urlContent);
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
                var title = await GetTitleTopMenu(idpart);
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
        public async Task<IActionResult> Recruitment(int? page,string? url)
        {

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    string jsonContent = await httpClient.GetStringAsync(
                        MyConstanst.SiteName 
                        + "web.all.url.asp?id1=" 
                        + url.Replace("%2F", "/"));
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<ApiModel> lstObj = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent, options);
                    if (lstObj[0].id != null)
                    {
                        List<BreadCrumbModel> breadCrumb = JsonSerializer.Deserialize<List<BreadCrumbModel>>
                            (await httpClient.GetStringAsync(
                                MyConstanst.SiteName
                                + "web.breadcrumb.asp?id="
                                + lstObj[0].id),options);

                        List<ApiModel> result = JsonSerializer.Deserialize<List<ApiModel>>
                            (await httpClient.GetStringAsync(
                                MyConstanst.SiteName 
                                + "module." 
                                + lstObj[0].module 
                                + ".asp?id=" + lstObj[0].id),options);                       
                        if (result.Count > 0)
                        {
                            int pageSize = (int)result[0].recordsFiltered;
                            int pageNumber = page == null || page < 0 ? 1 : page.Value;
                            ViewBag.BreadCrumb = breadCrumb;
                            PagedList<ApiModel.DataDetail> lst = new PagedList<ApiModel.DataDetail>(result[0].data, pageNumber, pageSize);
                            ViewData["Title"] = lstObj[0].tieude;
                            return View(lst);
                        }
                        else
                        {
                            return RedirectToAction("Recruitment", "Home");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return RedirectToAction("Index","Home");
        }

        [Route("tuyen-thuc-tap-sinh")]
        public async Task<IActionResult> Intern()
        {
            const string key = "tuyen-thuc-tap-sinh";
            try {
                List<ApiModel> webAllUrl = await GetInfoContent(key);
                ViewBag.BreadCrumb = await GetValueBreadCrumb(int.Parse(webAllUrl[0].id));
                ViewBag.Content = await GetContent(webAllUrl[0].id, webAllUrl[0].tenham);
                return View(webAllUrl);
            }
            catch
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
        public async Task<IActionResult> Search(string? url)
        {
            try
            {
                using(HttpClient httpClient = new HttpClient())
                {
                    if(url != null)
                    {
                        string urlApi = MyConstanst.SiteName+"web.all.url.asp?id1=" + url;

                        string jsonContent = await httpClient.GetStringAsync(urlApi);

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

                        var list = JsonSerializer.Deserialize<List<ApiModel>>(jsonContent, options);

                        if (list.Count != 0)
                        {
                            int id = int.Parse(list[0].id);

                            string apiWebBoLoc = MyConstanst.SiteName + "web.boloc.asp?id=" + id;
                            string apiBreadCrumb = MyConstanst.SiteName + "web.breadcrumb.asp?id=" + id;
                            string apiResultBoLoc = MyConstanst.SiteName + "module." + list[0].module + ".asp?id=" + id;

                            List<ApiModel.BoLoc> boLoc = JsonSerializer
                                .Deserialize<List<ApiModel
                                .BoLoc>>(
                                await httpClient
                                .GetStringAsync(urlApi)
                                , options);
                            List<BreadCrumbModel> breadCrumb = JsonSerializer
                                .Deserialize<List<BreadCrumbModel>>(
                                await httpClient
                                .GetStringAsync(apiBreadCrumb)
                                , options);
                            List<ApiModel> result = JsonSerializer
                                .Deserialize<List<ApiModel>>(
                                await httpClient
                                .GetStringAsync(apiResultBoLoc)
                                , options);

                            ViewBag.BreadCrumb = breadCrumb;
                            ViewData["Title"] = list[0].tieude;
                            return View(result[0].data);
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel? searchViewModel)
        {
            var url = MyConstanst.SiteName +"module.timboloc.asp?id=&id1=&id2=";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    if (searchViewModel.id != null && searchViewModel.id2 == null)
                    {
                        var _id = ReplaceSpacesWithPercent20(searchViewModel.id);
                        url = MyConstanst.SiteName +"module.timboloc.asp?id=" + _id + "&id1=&id2=";

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
                        url = MyConstanst.SiteName +"module.timboloc.asp?id=" + _id2 + "&id1=&id2=" + _id;
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

        [HttpGet]
        public async Task<IActionResult> JobDetail(int? id, string key)
        {
            var urlResult = MyConstanst.SiteName +"web.all.url.asp?id1="+key;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
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