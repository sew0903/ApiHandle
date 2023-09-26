using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using ProjectTestApi.Models;
using System.Diagnostics;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace ProjectTestApi.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public const string _url = "http://ww2.tuyennhansu.vn/";
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
                var json = (new WebClient()).DownloadString("http://ww2.tuyennhansu.vn/web.trangchu.module.content.asp");
                var list = JsonSerializer.Deserialize<List<ApiModel>>(json);
                return View(list);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("Home/tin-tuc")]
        public async Task<IActionResult> News()
        {
            const int idpart = 35001;
            string data = "";
            try
            {
                var obj = _listNewsModels(idpart);

                TempData["ControllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
                TempData["ActionName"] = this.ControllerContext.RouteData.Values["action"].ToString();
                ViewBag.DataJson = data;

                return View(obj);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("/{url}")]
        public async Task<IActionResult> News(string url)
        {
            const int idpart = 35001;
            var data = "";
            if (GetNameUrl(url))
            {
                try
                {
                    var obj = _listNewsModels(idpart);

                    TempData["ControllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
                    TempData["ActionName"] = this.ControllerContext.RouteData.Values["action"].ToString();

                    return View(obj);
                }catch(Exception e)
                {
                    notice = e.Message.ToString();
                }
            }
            return Json(notice);
        }

        [Route("can-tuyen-thuc-tap-sinh")]
        [Route("Home/can-tuyen-thuc-tap-sinh")]
        public async Task<IActionResult> Recruitment()
        {
            string data = "";
            const int idpart = 35004;
            try
            {
                var obj = _listRecruitmentModels(idpart/*,ref data*/);

                TempData["ControllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
                TempData["ActionName"] = this.ControllerContext.RouteData.Values["action"].ToString();
                ViewBag.DataJson = data;

                return View(obj);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }
        public async Task<IActionResult> Recruitment(int IdPart)
        {
            const int idpart = 35004;
            var data = "";

            if (idpart == IdPart)
            {
                try
                {
                    var obj = _listRecruitmentModels(idpart/*, ref data*/);

                    TempData["ControllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
                    TempData["ActionName"] = this.ControllerContext.RouteData.Values["action"].ToString();

                    return View(obj);
                }
                catch(Exception e) { notice = e.Message.ToString();}
            }
            return Json(notice);
        }

        [Route("ho-so-thuc-tap-sinh")]
        [Route("Home/ho-so-thuc-tap-sinh")]
        public async Task<IActionResult> Intern()
        {
            var data = "";
            const int idpart = 35031;
            try
            {
                var obj = _listInternModels(idpart);

                TempData["ControllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
                TempData["ActionName"] = this.ControllerContext.RouteData.Values["action"].ToString();
                ViewBag.DataJson = data;

                return View(obj);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }

        public async Task<IActionResult> Intern(int IdPart)
        {
            const int idpart = 35031;
            var data = "";
            if (idpart == IdPart)
            {
                try
                {
                    var obj = _listInternModels(idpart/*, ref data*/);

                    TempData["ControllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
                    TempData["ActionName"] = this.ControllerContext.RouteData.Values["action"].ToString();

                    return View(obj);
                }catch(Exception e)
                {
                    notice = e.Message.ToString();
                }
            }
            return Json(notice);
        }

        [Route("ban-do")]
        [Route("Home/ban-do")]
        public async Task<IActionResult> Map()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string ReadJson(string url)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string json = (new WebClient()).DownloadString(url);
            return json;
        }

        private string ApiMenuItem(int key)
        {
            //string domainName = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            string json = ReadJson(_url + "app.menu.dautrang.asp");
            var list = JsonSerializer.Deserialize<List<ApiModel>>(json);

            foreach(var js in list)
            {
                if(js.idpart == key.ToString())
                {
                    var result = _url+ "module."+js.kieuhienthi+".trangchu.asp?id="+js.idpart;
                    return result;
                }
            }
            return null;
        }

        private async Task FilterHandle()
        {

        }

        private List<ApiModel> _listNewsModels(int key/*,ref string data*/)
        {
            string json = ReadJson(ApiMenuItem(key));
            //data = json;
            return JsonSerializer.Deserialize<List<ApiModel>>(json); ;
        }

        private List<ApiModel> _listRecruitmentModels(int key/*, ref string data*/)
        {
            string json = ReadJson(ApiMenuItem(key));
            //data = json;
            return JsonSerializer.Deserialize<List<ApiModel>>(json); ;
        }

        private List<ApiModel> _listInternModels(int key/*,ref string data*/)
        {
            string json = ReadJson(ApiMenuItem(key));
            //data = json;
            return JsonSerializer.Deserialize<List<ApiModel>>(json); ;
        }

        private List<ApiModel> GetHomeContent()
        {
            List<ApiModel> result = new List<ApiModel>();

            string json = ReadJson(_url + "web.trangchu.module.content.asp");
            var list = JsonSerializer.Deserialize<List<ApiModel>>(json);

            foreach (var js in list)
            {
                result.Add(js);
            }
            return result;
        }

        private bool GetNameUrl(string url)
        {
            string json = ReadJson(_url + "app.menu.dautrang.asp");
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
    }
}