using Microsoft.AspNetCore.Mvc;
using ProjectTestApi.Models.ViewModel;
using ProjectTestApi.Controllers;
using System.Security.Policy;
using ProjectTestApi.Models.API;
using System.Text.Json;
using System.Net.Http;
using ProjectTestApi.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using ProjectTestApi.Models.Const;
using System.Net.Http.Json;
using System;

namespace ProjectTestApi.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("cv-cua-ung-vien")]
        public async Task<IActionResult> InfoCvUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InfoCvUser(HttpClient httpClient)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProfileUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CvJobApplicationUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShareCvJobApplicationUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> JobAnnouncementUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SaveJobsUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PasswordUser()
        {
            return View();
        }

    }
}
