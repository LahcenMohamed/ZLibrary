using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZLibrary.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}