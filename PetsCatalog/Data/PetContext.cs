using Microsoft.EntityFrameworkCore;
using PetsCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsCatalog.Data
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
                new { AnimalId = 1, Name = "Pug", Age = 5, PictureName = "dog1.jpg", Description = "The pug is a breed of dog distinguished by a wrinkly, short-muzzled face and curled tail.", CategoryId = 1 },
                new { AnimalId = 2, Name = "Shih Tzu", Age = 3, PictureName = "dog2.jpg", Description = "The Shih Tzu is a sturdy little dog with a short muzzle and normally have large dark brown eyes.", CategoryId = 1 },
                new { AnimalId = 3, Name = "Pomeranian", Age = 2, PictureName = "dog3.jpg", Description = "The Pomeranian (often known as a Pom) is a breed of dog of the Spitz type that is named for the Pomerania region in north-west Poland and north-east Germany in Central Europe.", CategoryId = 1 },
                new { AnimalId = 4, Name = "Poodle", Age = 10, PictureName = "dog4.jpg", Description = "The Poodle is a dog breed that comes in three varieties: Standard Poodle, Miniature Poodle, and Toy Poodle.", CategoryId = 1 },
                new { AnimalId = 5, Name = "Beagle", Age = 7, PictureName = "dog5.jpg", Description = "The beagle is a breed of small hound that is similar in appearance to the much larger foxhound.", CategoryId = 1 },
                new { AnimalId = 6, Name = "Maine coon", Age = 2, PictureName = "cat1.jpg", Description = "The Maine Coon is the largest domesticated cat breed. It has a distinctive physical appearance and valuable hunting skills.", CategoryId = 1 },
                new { AnimalId = 7, Name = "Calico cat", Age = 15, PictureName = "cat2.jpg", Description = "A calico cat is a domestic cat of any breed with a tri-color coat.", CategoryId = 1 },
                new { AnimalId = 8, Name = "British shorthair", Age = 7, PictureName = "cat3.jpg", Description = "The British Shorthair is the pedigreed version of the traditional British domestic cat, with a distinctively stocky body, dense coat, and broad face.", CategoryId = 1 },
                new { AnimalId = 9, Name = "Ragdoll", Age = 4, PictureName = "cat4.jpg", Description = "The Ragdoll is a cat breed with a color point coat and blue eyes. They are large and muscular semi-longhair cats with a soft and silky coat.", CategoryId = 1 },
                new { AnimalId = 10, Name = "Exotic shorthair", Age = 7, PictureName = "cat5.jpg", Description = "The Exotic Shorthair is a breed of cat developed as a short-haired version of the Persian.", CategoryId = 1 },
                new { AnimalId = 11, Name = "Dutch rabbit", Age = 20, PictureName = "bunny1.jpg", Description = "The Dutch rabbit, also known as Hollander or Brabander is easily identifiable by its characteristic colour pattern, and was once the most popular of all rabbit breeds.", CategoryId = 1 },
                new { AnimalId = 12, Name = "Lionhead rabbit", Age = 15, PictureName = "bunny2.jpg", Description = "The Lionhead rabbit has a wool mane encircling the head, reminiscent of a male lion as its name implies.", CategoryId = 1 },
                new { AnimalId = 13, Name = "Holland lop rabbit", Age = 10, PictureName = "bunny3.jpg", Description = "The Holland Lop, with a maximum weight of 4 lb is one of the smallest lop-eared breeds.", CategoryId = 1 },
                new { AnimalId = 14, Name = "English lop rabbit", Age = 5, PictureName = "bunny4.jpg", Description = "The English Lop is a fancy breed of domestic rabbit that was developed in England in the 19th century through selective breeding.", CategoryId = 1 },
                new { AnimalId = 15, Name = "English angora rabbit", Age = 2, PictureName = "bunny5.jpg", Description = " The Angora rabbit which is one of the oldest types of domestic rabbit, is bred for the long fibers of its coat, known as Angora wool, which are gathered by shearing, combing or plucking.", CategoryId = 1 },
                new { AnimalId = 16, Name = "Tiger barb fish", Age = 5, PictureName = "fish1.jpg", Description = "The tiger barb or Sumatra barb is a species of tropical cyprinid fish.", CategoryId = 3 },
                new { AnimalId = 17, Name = "Goldfish", Age = 5, PictureName = "fish2.jpg", Description = "The common goldfish is a breed of goldfish with no other differences from its living ancestor, the Prussian carp, other than its color and shape.", CategoryId = 3 },
                new { AnimalId = 18, Name = "Greek tortoise", Age = 5, PictureName = "turtle1.jpg", Description = "The Greek tortoise is a species of tortoise in the family Testudinidae. Testudo graeca is one of five species of Mediterranean tortoises.", CategoryId = 2 },
                new { AnimalId = 19, Name = "Sea turtle", Age = 5, PictureName = "turtle2.jpg", Description = "Sea turtles are reptiles of the order Testudines and of the suborder Cryptodira.", CategoryId = 2 }
            );

            modelBuilder.Entity<Category>().HasData(
                 new { CategoryId = 1, Name = "Mamal" },
                 new { CategoryId = 2, Name = "Reptile" },
                 new { CategoryId = 3, Name = "Aquatic" }
               );


            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, CommentData = "This is the first comment", AnimalId = 1 },
                new { CommentId = 2, CommentData = "This is the second comment", AnimalId = 2 }
            );
        }
    }
}
