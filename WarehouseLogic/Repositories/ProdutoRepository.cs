using System.Collections.ObjectModel;
using WarehouseLib.Interfaces;
using WarehouseLib.Models;
using WarehouseLogic.Context;

namespace WarehouseLogic.Repositories
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private readonly SQLiteDbContext _dbContext;

        public ProdutoRepository(SQLiteDbContext context)
        {
            _dbContext = context;
        }

        public void Add(Produto entity) => _dbContext.Add(entity);
        public ObservableCollection<Produto> GetAll() => _dbContext.Set<Produto>().Local.ToObservableCollection();
        public Produto GetById(int id) => _dbContext.Set<Produto>().Find(id);
        public void Update(Produto entity) => _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        public void Delete(int id) => _dbContext.Remove(GetById(id));
        public void SaveChanges() => _dbContext.SaveChanges();
    }
}
