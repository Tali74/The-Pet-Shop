using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Pro2.Models;
using Pro2.Repositories;

namespace Pro2.Controllers {
    public class CatalogController : Controller {
        private IPetRepository _petRepository;
        public CatalogController(IPetRepository petRepository) {
            _petRepository = petRepository;
        }

        public IActionResult Index(Category category) {
            ViewBag.Categories = _petRepository.AllCategories();
            return View(_petRepository.GetByCategory(category));
        }
        public IActionResult AnimalDetails(int id) {
            return View(_petRepository.GetAnimalById(id));
        }
        public IActionResult AddComment(Comment comment) {
            _petRepository.AddComment(comment);
            return RedirectToAction("AnimalDetails", new { id = comment.AnimalId });
        }
    }
}
