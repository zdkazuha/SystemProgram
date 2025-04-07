using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Library.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Title { get; set; }
        [MaxLength(50),Required]
        public string Genre { get; set; }
        [Required]
        public int AuthorId { get; set; }

        // Navigation property

        public Author Author { get; set; }

        public override string ToString()
        {
            return $"{Title} {Genre}";
        }
    }
}
