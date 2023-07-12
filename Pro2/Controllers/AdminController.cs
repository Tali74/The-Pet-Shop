using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pro2.Models;
using Pro2.Repositories;

namespace Pro2.Controllers {
    public class AdminController : Controller {
        private readonly IPetRepository _repository;
        private readonly IWebHostEnvironment host;
        public AdminController(IPetRepository repository, IWebHostEnvironment host) {
            _repository = repository;
            this.host = host;
        }

        public IActionResult Index(Category category) {
            ViewBag.Categories = _repository.AllCategories();
            return View(_repository.GetByCategory(category));
        }
        [HttpGet]
        public IActionResult CreateAnimal() {
            ViewBag.Categories = _repository.AllCategories();
            return View("CreateAnimal");
        }
        [HttpPost]
        public IActionResult CreateAnimal(Animal animal) {
            animal.PicturePath = FileHendel(animal.PictureFile);
            _repository.AddAnimal(animal);
            return RedirectToAction(nameof(Index), animal.Category);
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            ViewBag.Categories = _repository.AllCategories();
            var animal = _repository.GetAnimalById(id);
            return View(animal);
        }
        [HttpPost]
        public IActionResult Edit(Animal animal) {
            if (animal.PictureFile != null) {
                animal.PicturePath = FileHendel(animal.PictureFile);
            }
            _repository.UpdateAnimal(animal);
            return RedirectToAction("Index", animal.Category);
        }
        public IActionResult Delete(int id) {
            var animal = _repository.GetAnimalById(id);
            _repository.DeleteAnimal(id);
            return RedirectToAction("Index");
        }
        private string? FileHendel(IFormFile? file) {
            var webRoot = host.WebRootPath;
            var path = $"{webRoot}/Pictures/{file!.FileName}";
            if (!System.IO.File.Exists(path)) {
                using (var stream = new FileStream(path, FileMode.Create)) {
                    file.CopyTo(stream);
                }
            }
            return "/Pictures/" + file.FileName;
        }
    }
}
