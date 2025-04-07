using Db_Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Surname = "Doe",
                    BookId = 1
                },
                new Author
                {
                    Id = 2,
                    Name = "Jane",
                    Surname = "Smith",
                    BookId = 2
                },
                new Author
                {
                    Id = 3,
                    Name = "Emily",
                    Surname = "Johnson",
                    BookId = 3
                },
                new Author
                {
                    Id = 4,
                    Name = "Michael",
                    Surname = "Brown",
                    BookId = 4
                },
                new Author
                {
                    Id = 5,
                    Name = "Sarah",
                    Surname = "Davis",
                    BookId = 5
                },
            });
        }
    }
}
