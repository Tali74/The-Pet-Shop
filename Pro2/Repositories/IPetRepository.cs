using Pro2.Data;
using Pro2.Models;

namespace Pro2.Repositories {
    public interface IPetRepository {
        void AddAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);
        IEnumerable<Animal> AllAnimals();
        IEnumerable<Animal> GetByCategory(Category category);
        IEnumerable<Animal> GetTopAnimals();
        void AddComment(Comment comment);
        Animal? GetAnimalById(int animalId);
        IEnumerable<Category> AllCategories();

    }
}
