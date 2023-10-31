using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZLibrary.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOfBorrowing { get; set; }

        [Required]
        public DateTime RedemptionDate { get; set; }

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }

        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client Client { get; set; }
    }
}
