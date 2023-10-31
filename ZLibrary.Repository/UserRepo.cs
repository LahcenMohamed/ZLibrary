using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZLibrary.Models;

namespace ZLibrary.Repository
{
    public class UserRepo : IDataHalper<User>
    {
        ZLibraryDbContext db = new ZLibraryDbContext();
        public async void Add(User table)
        {
            await db.Users.AddAsync(table);
            await db.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var user = await GetById(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {
            var user = await db.Users.FindAsync(id);
            return user;
        }
        public async Task<bool> CheckAccount(string name, string password)
        {
            var check = await db.Users.AnyAsync(x => x.Name == name && x.Password == password);
            return check;
        }

        public Task<List<User>> SearchAsync(string item)
        {
            throw new NotImplementedException();
        }

        public async void Update(User table)
        {
            db.Users.Update(table);
            await db.SaveChangesAsync();
        }
    }
}
