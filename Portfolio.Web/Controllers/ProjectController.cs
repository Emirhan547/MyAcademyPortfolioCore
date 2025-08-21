﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ProjectController(PortfolioContext context) : Controller
    {
        public void CategoryDropDown()
        {
            var categories = context.Categories.ToList();
            ViewBag.categories = (from x in categories
                                  select new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  }).ToList();
        }
        public IActionResult Index()
        {
            var projects = context.Projects.Include(x => x.Category).ToList();
            return View(projects);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            CategoryDropDown();

            return View();
        }
        [HttpPost]
        public IActionResult CreateProject(Project model)
        {
            CategoryDropDown();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            context.Projects.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var project = context.Projects.Find(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project model)
        {
            CategoryDropDown();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            context.Projects.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteProject(int id)
        {
            var project = context.Projects.Find(id);
            
                context.Projects.Remove(project);
                context.SaveChanges();
                return RedirectToAction("Index");

        }

    }
}
