using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using Pro2.Data;
using Pro2.Models;

namespace Pro2.Repositories {
    public class PetRepository : IPetRepository {
        private PetContext _context;
        public PetRepository(PetContext context) {
            _context = context;
        }


        public void AddAnimal(Animal animal) {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }


        public void UpdateAnimal(Animal animal) {
            var animalInDb = GetAnimalById(animal.AnimalId);
            animalInDb!.CategoryId = animal.CategoryId;
            animalInDb!.AnimalName = animal.AnimalName;
            animalInDb.AnimalAge = animal.AnimalAge;
            animalInDb.PicturePath = animal.PicturePath;
            animalInDb.Description = animal.Description;
            _context.SaveChanges();
        }

        public void DeleteAnimal(int id) {
            var animal = GetAnimalById(id);
            _context.Animals.Remove(animal!);
            _context.SaveChanges();
        }

        public IEnumerable<Animal> GetByCategory(Category category) {
            return category == null || category.CategoryId == 0 ? AllAnimals() :
                AllAnimals().Where(a => a.Category!.CategoryId == category.CategoryId);
        }

        public IEnumerable<Animal> GetTopAnimals() {
            return AllAnimals().OrderByDescending(c => c.Comments!.Count).Take(2);
        }

        public void AddComment(Comment comment) {
            var animal = GetAnimalById(comment.AnimalId);
            animal?.Comments?.Add(comment);
            _context.SaveChanges();
        }

        public Animal? GetAnimalById(int animalId) {
            return AllAnimals().SingleOrDefault(m => m.AnimalId == animalId);
        }

        public IEnumerable<Animal> AllAnimals() => _context.Animals
            .Include(x => x.Comments)
            .Include(x => x.Category);

        public IEnumerable<Category> AllCategories() => _context.Categories;
    }
}
