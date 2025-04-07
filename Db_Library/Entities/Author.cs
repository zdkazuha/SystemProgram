using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Library.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        [MaxLength(50), Required]
        public string Surname { get; set; }
        [Required]
        public int BookId { get; set; }

        // Navigation property

        public ICollection<Book> Books { get; set; }
    }
}
