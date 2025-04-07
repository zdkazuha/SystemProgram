using Db_Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Db_Library
{
    public static class InitializerDb
    {
        public static void SeedBook(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    Genre = "Fiction",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    Genre = "Fiction",
                    AuthorId = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "1984",
                    Genre = "Dystopian",
                    AuthorId = 3
                },
                new Book
                {
                    Id = 4,
                    Title = "Pride and Prejudice",
                    Genre = "Romance",
                    AuthorId = 4
                },
                new Book
                {
                    Id = 5,
                    Title = "The Catcher in the Rye",
                    Genre = "Fiction",
                    AuthorId = 5
                },
                new Book
                {
                    Id = 6,
                    Title = "The Hobbit",
                    Genre = "Fantasy",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 7,
                    Title = "Brave New World",
                    Genre = "Dystopian",
                    AuthorId = 2
                },
                new Book
                {
                    Id = 8,
                    Title = "Book",
                    Genre = "Fantasy",
                    AuthorId = 5
                },
                new Book
                {
                    Id = 9,
                    Title = "The Alchemist",
                    Genre = "Adventure",
                    AuthorId = 3
                },
                new Book
                {
                    Id = 10,
                    Title = "The Picture of Dorian Gray",
                    Genre = "Horror",
                    AuthorId = 4
                }
            });
        }
        public static void SeedAuthor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Doe"
                },
                new Author
                {
                    Id = 2,
                    Name = "Jane",
                    Surname = "Smith"
                },
                new Author
                {
                    Id = 3,
                    Name = "Emily",
                    Surname = "Johnson"
                },
                new Author
                {
                    Id = 4,
                    Name = "Michael",
                    Surname = "Brown"
                },
                new Author
                {
                    Id = 5,
                    Name = "Sarah",
                    Surname = "Davis"
                },
                new Author
                {
                    Id = 6,
                    Name = "David",
                    Surname = "Wilson"
                },
                new Author
                {
                    Id = 7,
                    Name = "Laura",
                    Surname = "Garcia"
                },
                new Author
                {
                    Id = 8,
                    Name = "James",
                    Surname = "Martinez"
                },
                new Author
                {
                    Id = 9,
                    Name = "Linda",
                    Surname = "Hernandez"
                },
                new Author
                {
                    Id = 10,
                    Name = "Robert",
                    Surname = "Lopez"
                },
            });
        }
    }
}
