using Microsoft.AspNetCore.Mvc;
using Pro2.Repositories;

namespace Pro2.Controllers {
    public class HomeController : Controller {
        private IPetRepository _repository;

        public HomeController(IPetRepository repository) {
            _repository = repository;
        }
        public IActionResult Index() {
            return View(_repository.GetTopAnimals());
        }

        public IActionResult Error() {
            return Content("Sorry. Not Today !!! ~_~ ");
        }

    }
}
