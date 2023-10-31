using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZLibrary.Repository
{
    public interface IDataHalper<Table>
    {
        void Add(Table table);
        void Update(Table table);
        void Delete(int id);
        Task<Table> GetById(int id);
        Task<List<Table>> GetAll();    
        Task<List<Table>> SearchAsync(string item);
    }
}
