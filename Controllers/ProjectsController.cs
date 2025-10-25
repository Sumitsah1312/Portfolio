using Microsoft.AspNetCore.Mvc;
using SumitPortfolio.Models;
using System.Collections.Generic;

namespace SumitPortfolio.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            var projects = new List<Project>
            {
                new Project { Title = "Project 1", Description = "Dummy description 1" },
                new Project { Title = "Project 2", Description = "Dummy description 2" },
                new Project { Title = "Project 3", Description = "Dummy description 3" },
            };
            return View(projects);
        }
    }
}
