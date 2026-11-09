using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using UzdevumuParvaldnieksKlases;

namespace UzdevumuParvaldnieksWeb.Controllers
{

    public class UzdevumiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UzdevumiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient Api => _httpClientFactory.CreateClient("UzdevumiApi");

        // GET: /Uzdevumi
        public async Task<IActionResult> Index()
        {
            try
            {
                var dati = await Api.GetFromJsonAsync<List<Uzdevums>>("Uzdevumi")
                           ?? new List<Uzdevums>();

                return View(dati);
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Error = $"Neizdevās sazināties ar API: {ex.Message}";
                return View(new List<Uzdevums>());
            }
        }

        // GET: /Uzdevumi/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await Api.GetAsync($"Uzdevumi/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound();

            response.EnsureSuccessStatusCode();

            var uzdevums = await response.Content.ReadFromJsonAsync<Uzdevums>();

            return uzdevums is null ? NotFound() : View(uzdevums);
        }

        // GET: /Uzdevumi/Create
        public IActionResult Create()
        {
            return View(new Uzdevums());
        }

        // POST: /Uzdevumi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Uzdevums uzdevums)
        {
            if (!ModelState.IsValid)
                return View(uzdevums);

            var response = await Api.PostAsJsonAsync("Uzdevumi", uzdevums);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "API neizdevās izveidot uzdevumu.");
                return View(uzdevums);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Uzdevumi/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await Api.GetAsync($"Uzdevumi/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound();

            response.EnsureSuccessStatusCode();

            var uzdevums = await response.Content.ReadFromJsonAsync<Uzdevums>();

            return uzdevums is null ? NotFound() : View(uzdevums);
        }

        // POST: /Uzdevumi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Uzdevums uzdevums)
        {
            if (id != uzdevums.ID)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(uzdevums);

            var response = await Api.PutAsJsonAsync($"Uzdevumi/{id}", uzdevums);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound();

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "API neizdevās saglabāt izmaiņas.");
                return View(uzdevums);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Uzdevumi/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Api.GetAsync($"Uzdevumi/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound();

            response.EnsureSuccessStatusCode();

            var uzdevums = await response.Content.ReadFromJsonAsync<Uzdevums>();

            return uzdevums is null ? NotFound() : View(uzdevums);
        }

        // POST: /Uzdevumi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await Api.DeleteAsync($"Uzdevumi/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound();

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "API neizdevās izdzēst uzdevumu.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
