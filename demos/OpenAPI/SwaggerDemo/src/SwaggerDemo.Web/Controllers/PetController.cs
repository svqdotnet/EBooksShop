using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwaggerDemo.Web.Models;

namespace SwaggerDemo.Web.Controllers
{
    public class PetController : Controller
    {
        private string _baseUrl;
        private IConfiguration _config;

        public IConfiguration Configuration { get; }

        public PetController(IConfiguration configuration)
        {
            _config = configuration;
            _baseUrl = _config.GetValue<string>("BaseUrl");
        }

        // GET: Pet
        public async Task<ActionResult> Index()
        {
            Client petClient = new Client() { BaseUrl = _baseUrl };
            var pets = await petClient.FindPetsByStatusAsync(new List<Anonymous>() { Anonymous.Available });

            return View(pets);
        }

        // GET: Pet/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Client petClient = new Client() { BaseUrl = _baseUrl };
            var pet = await petClient.GetPetByIdAsync(id);

            return View(pet);
        }

        // GET: Pet/Create
        public async Task<ActionResult> Create(Pet pet)
        {
            Client petClient = new Client() { BaseUrl = _baseUrl };
            await petClient.AddPetAsync(pet);

            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
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

        public async Task<ActionResult> Edit(long id)
        {
            Client petClient = new Client() { BaseUrl = _baseUrl };
            var pet = await petClient.GetPetByIdAsync(id);

            return View(pet);
        }

        // POST: Pet/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromForm]Pet pet)
        {
            try
            {
                Client petClient = new Client() { BaseUrl = _baseUrl };
                await petClient.UpdatePetAsync(pet);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Pet/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            Client petClient = new Client() { BaseUrl = _baseUrl };
            var pet = await petClient.GetPetByIdAsync(id);

            return View(pet);
        }

        // POST: Pet/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id, IFormCollection collection)
        {
            try
            {
                Client petClient = new Client() { BaseUrl = _baseUrl };
                await petClient.DeletePetAsync("", id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}