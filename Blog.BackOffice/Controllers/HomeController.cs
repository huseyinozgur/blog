using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.BackOffice.Models;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Blog.Business.CQRS.BackOffice.Blogs.Queries;

namespace Blog.BackOffice.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //public IMediator Mediator { get; }

        //public HomeController(IMediator mediator)
        //{
        //    Mediator = mediator;
        //}

        public IActionResult Index()
        {
            //var a = await Mediator.Send(new BlogsQuery { });
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
