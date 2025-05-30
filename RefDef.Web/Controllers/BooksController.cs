using Microsoft.AspNetCore.Mvc;
using RefDef.Web.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace RefDef.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient _httpClient;

        public BooksController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7000/api/");
        }

        public async Task<IActionResult> Index()
        {
            var books = await GetApiData<List<Book>>("books");
            return View(books ?? new());
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await GetApiData<Book>($"books/{id}");
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = await LoadFormOptions(new BookFormViewModel());
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookFormViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("books", model.Book);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            model = await LoadFormOptions(model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await GetApiData<Book>($"books/{id}");
            if (book == null) return NotFound();

            var vm = new BookFormViewModel { Book = book };
            return View(await LoadFormOptions(vm));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookFormViewModel model)
        {
            if (id != model.Book.Id) return BadRequest();

            var response = await _httpClient.PutAsJsonAsync($"books/{id}", model.Book);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            model = await LoadFormOptions(model); 
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await GetApiData<Book>($"books/{id}");
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"books/{id}");
            return RedirectToAction("Index");
        }

        private async Task<BookFormViewModel> LoadFormOptions(BookFormViewModel model)
        {
            model.Authors = await GetApiData<List<Author>>("authors") ?? new();
            model.Categories = await GetApiData<List<Category>>("categories") ?? new();
            model.Publishers = await GetApiData<List<Publisher>>("publishers") ?? new();
            return model;
        }

        private async Task<T?> GetApiData<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode) return default;
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
