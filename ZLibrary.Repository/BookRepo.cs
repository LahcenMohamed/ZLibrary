using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZLibrary.Models;

namespace ZLibrary.Repository
{
    public class BookRepo : IDataHalper<Book>
    {
        ZLibraryDbContext db;
        public BookRepo()
        {
            db = new ZLibraryDbContext();
        }
        public async void Add(Book table)
        {
            await db.Books.AddAsync(table);
            await db.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var book = await GetById(id);
            db.Books.Remove(book);
            await db.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAll()
        {
          List<Book> books = await db.Books.Include(d => d.Category).ToListAsync();
          return books;
        }

        public async Task<Book> GetById(int id)
        {
            
            var book = await db.Books.FindAsync(id);
            return book;
        }

        public async Task<List<Book>> SearchAsync(string item)
        {
            var fillteBooks = await db.Books.Include(x => x.Category).Where(x => x.Id.ToString() == item ||
                                                        x.Name.Contains(item) ||
                                                        x.Author.Contains(item) ||
                                                        x.Publisher.Contains(item) ||
                                                        x.CountOfCopies.ToString() == item||
                                                        x.Category.Name.Contains(item)).ToListAsync();
            return fillteBooks;
        }

        public async void Update(Book table)
        {
            db = new ZLibraryDbContext();
            db.Books.Update(table);
            await db.SaveChangesAsync();
        }
    }
}
