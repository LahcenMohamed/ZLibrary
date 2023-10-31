using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZLibrary.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(65)]
        public string Name { get; set; }

        [Required]
        [StringLength(55)]
        public string Password { get; set; }

        [Required]
        [StringLength(35)]
        [RegularExpression("Admin|Client|Manager")]
        public string Type { get; set; }
    }
}
