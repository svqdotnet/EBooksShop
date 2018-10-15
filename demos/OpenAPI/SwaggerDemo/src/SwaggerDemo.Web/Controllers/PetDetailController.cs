using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SwaggerDemo.Web.Controllers
{
    public class PetDetailController : Controller
    {
        private string _baseUrl;
        private IConfiguration _config;

        public IConfiguration Configuration { get; }

        public PetDetailController(IConfiguration configuration)
        {
            _config = configuration;
        }

        // GET: PetDetail
        public async Task<ActionResult> Index(long id)
        {
            _baseUrl = _config.GetValue<string>("BaseUrl");

            Client petClient = new Client() { BaseUrl = _baseUrl };
            var pet = await petClient.GetPetByIdAsync(id);

            return View(pet);
        }

        // GET: PetDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PetDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PetDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PetDetail/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PetDetail/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}