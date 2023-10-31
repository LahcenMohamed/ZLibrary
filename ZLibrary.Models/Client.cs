using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZLibrary.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        [StringLength(55)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(35)]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfAccession { get; set; }

        [Required]
        public DateTime Birth { get; set; }
        public List<Loan> Loans { get; set; } = new List<Loan>();
    }
}
