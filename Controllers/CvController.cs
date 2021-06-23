using System;
using Microsoft.AspNetCore.Mvc;

namespace Curriculum_WebApp.Controllers
{
    public class CvController : Controller
    {

        public CvController() { }

        public IActionResult Index()
        {
            return PartialView();
        } 

    }
}