using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZLibrary.Models;

namespace ZLibrary.Repository
{
    public class CategoryRepo
    {
        ZLibraryDbContext db = new ZLibraryDbContext();
        public CategoryRepo()
        {
        }
        public async Task<List<string>> GetNames()
        {
            var names = await db.Categories.Select(c => c.Name).ToListAsync();
            return names;
        }
        public async Task<int> FindByName(string? name)
        {
            var cat = await db.Categories.FirstOrDefaultAsync(x => x.Name == name);
            int id = cat.Id;
            return id;
        }
        public async void Add(Category name)
        {
            await db.Categories.AddAsync(name);
            await db.SaveChangesAsync();
        }
    }
}
