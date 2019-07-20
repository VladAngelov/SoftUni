using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        #region Atribute Routing

        [HttpGet("Blog/{username}")]
        [HttpGet("User/{username}")]
        [HttpGet("MyProfile")]
        [Authorize]
        public IActionResult MyCustomActionName(string username)
        {
            return this.Content(username);
        }
        // ще работи в синхрон с другите route-ове

        #endregion

        #region Conventional Routing 
        [Authorize]
        public IActionResult BlogArticle(int year, int month, int day, string slug)
        {
            return this.Json(new { year, month, day, slug });
        }

        #endregion

        public IActionResult Details(int id)
        //  public async Task<IActionResult> Details(int id)

        {
            //   var viewModel = await this.dataService.GetByIdAsync(id).To<Details>();
            //   return this.View(viewModel);

            return this.View();
        }

        public IActionResult Index()
        {
            // return this.StatusCode((int)HttpStatusCode.BadRequest); // връщане на статус код
            // return PartialView(); // връща само HTML без CSS
            // return this.Redirect("https://softuni.bg"); // препращане към сайт (302)

            //this.ViewBag.MyProp = "Vladi"; // вариант 1
            //this.ViewData["MyProp"] = "Vladi"; // вариант 2
            //return View(class.MyProp); // най-правилен вариант

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}