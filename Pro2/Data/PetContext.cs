using Microsoft.EntityFrameworkCore;
using Pro2.Models;

namespace Pro2.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, AnimalName = "Nova Scotia", AnimalAge = 5, PicturePath = "/Pictures/Dog-Nova.jpg", Description = " It is a medium-sized gundog bred primarily for hunting. It is the smallest of the retrievers. It is intelligent, eager to please, alert, and energetic.", CategoryId = 1 },
                new { AnimalId = 2, AnimalName = "Tabby cat", AnimalAge = 3, PicturePath = "/Pictures/Cat-Tabby.jpg", Description = "It is any domestic cat with a distinctive 'M'-shaped marking on its forehead; stripes by its eyes and across its cheeks, along its back, and around its legs and tail. It is not a breed of cat", CategoryId = 2 },
                new { AnimalId = 3, AnimalName = "Fantail", AnimalAge = 1, PicturePath = "/Pictures/Fish-Fantail.jfif", Description = "It is a goldfish that possesses an egg-shaped body, a high dorsal fin, a long quadruple caudal fin, and no shoulder hump.", CategoryId = 3 },
                new { AnimalId = 4, AnimalName = "Golden hamster", AnimalAge = 1, PicturePath = "/Pictures/Golden hamster.jpg", Description = "It is a rodent belonging to the hamster subfamily, Cricetinae. Their natural geographical range is in an arid region of northern Syria and southern Turkey.", CategoryId = 4 },
                new { AnimalId = 5, AnimalName = "Yellow-naped amazon", AnimalAge = 6, PicturePath = "/Pictures/Yellow-naped amazon.jpg", Description = "It is a widespread amazon parrot sometimes considered to be a subspecies of the yellow-crowned amazon. It inhabits the Pacific coast of southern Mexico and Central America", CategoryId = 5 },
                new { AnimalId = 6, AnimalName = "Holland Lop", AnimalAge = 1, PicturePath = "/Pictures/Holland Lop.jpg", Description = "It has a maximum weight of 4 lb, is one of the smallest lop-eared breeds. Holland Lops are one of the most popular rabbit breeds in the United States and the United Kingdom.", CategoryId = 6 },
                new { AnimalId = 7, AnimalName = "Okeetee Corn Snake", AnimalAge = 2, PicturePath = "/Pictures/Okeetee Corn Snake.jpeg", Description = "It's color is bright orange and their saddle markings are bright red. The black outline of their saddle markings is thicker. Okeetee corn snakes are no different from regular corn snakes.", CategoryId = 7 },
                new { AnimalId = 8, AnimalName = "Yorkshire Terrier", AnimalAge = 2, PicturePath = "/Pictures/yorkshire-Dog.jpg", Description = "It is a British breed of toy dog of terrier type. It is among the smallest of the terriers and indeed of all dog breeds, with a weight of no more than 3.2 kg.", CategoryId = 1 },
                new { AnimalId = 9, AnimalName = "British Shorthair", AnimalAge = 3, PicturePath = "/Pictures/british-shorthair-cat__1_.jpg", Description = "It is the pedigreed version of the traditional British domestic cat, with a distinctively stocky body, dense coat, and broad face. The most familiar colour variant is the \"British Blue\", with a solid grey-blue coat, orange eyes, and a medium-sized tail.", CategoryId = 2 },
                new { AnimalId = 10, AnimalName = "Phodopus sungorus", AnimalAge = 1, PicturePath = "/Pictures/djungarian-hamster-phodopus-sungorus-27725846.jpg", Description = "It is one of three species of hamster in the genus Phodopus. It is ball-shaped and typically half the size of the Syrian hamster. Features of the winter white hamster include a typically thick, dark grey dorsal stripe and furry feet. As winter approaches and the days shorten, the winter white dwarf hamster's dark fur is almost entirely replaced with white fur.", CategoryId = 4 }

                );

            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, CategoryName = "Dogs" },
                new { CategoryId = 2, CategoryName = "Cats" },
                new { CategoryId = 3, CategoryName = "Fish" },
                new { CategoryId = 4, CategoryName = "Hamster" },
                new { CategoryId = 5, CategoryName = "Parrot" },
                new { CategoryId = 6, CategoryName = "Rabbit" },
                new { CategoryId = 7, CategoryName = "Snake" }
                );

            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, CommentText = "Cute", AnimalId = 1 },
                new { CommentId = 2, CommentText = "Fun", AnimalId = 1 },
                new { CommentId = 3, CommentText = "Funny", AnimalId = 2 },
                new { CommentId = 4, CommentText = "Furry", AnimalId = 2 },
                new { CommentId = 5, CommentText = "friendly", AnimalId = 4 },
                new { CommentId = 6, CommentText = "pretty", AnimalId = 3 },
                new { CommentId = 7, CommentText = "colourful", AnimalId = 5 },
                new { CommentId = 8, CommentText = "talks alot", AnimalId = 5 },
                new { CommentId = 9, CommentText = "supporter", AnimalId = 1 },
                new { CommentId = 10, CommentText = "play a lot", AnimalId = 6 },
                new { CommentId = 11, CommentText = "relaxing", AnimalId = 7 },
                new { CommentId = 12, CommentText = "soft", AnimalId = 6 },
                new { CommentId = 13, CommentText = "playful ", AnimalId = 8 },
                new { CommentId = 14, CommentText = "energetic ", AnimalId = 8 },
                new { CommentId = 15, CommentText = "easy-going personality ", AnimalId = 9 },
                new { CommentId = 16, CommentText = "gets along with everyone ", AnimalId = 9 }



                );
        }
    }
}
