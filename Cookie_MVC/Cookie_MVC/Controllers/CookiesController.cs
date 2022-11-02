using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cookie_MVC.Data;
using Cookie_MVC.Models;
using Cookie_MVC.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace Cookie_MVC.Controllers
{
    public class CookieController : Controller
    {
        private ICookieService? _service;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7179/api/Cookie/";

        public CookieController(ICookieService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");
        }

        // Example: https://localhost:7256/api/VideoGames
        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();

            return View(response);
        }

        // GET: Cookie/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cookie = await _service.FindOne(id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // GET: VideoGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGame/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Flavor,Quantity")] Cookie cookie)
        {
            cookie.Id = null;
            var resultPost = await client.PostAsync<Cookie>(requestUri, cookie, new System.Net.Http.Formatting.JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cookie = await _service.FindOne(id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // POST: VideoGame/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Flavor, Quantity")] Cookie cookie)
        {
            if (id != cookie.Id)
            {
                return NotFound();
            }

            var resultPut = await client.PutAsync<Cookie>(requestUri + cookie.Id.ToString(), cookie, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: Cookie/Delete/5
        public async Task<IActionResult> Delete(int id)

        {
            var cookie = await _service.FindOne(id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // POST: Cookie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}