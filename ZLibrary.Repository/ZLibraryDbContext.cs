using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZLibrary.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZLibrary.Repository
{
    public class ZLibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source =.\SQLEXPRESS; initial catalog = ZLWPFDB; integrated security = True; Encrypt = False; MultipleActiveResultSets = True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

    }
}
