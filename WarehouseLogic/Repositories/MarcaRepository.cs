using System.Collections.Generic;
using System.Collections.ObjectModel;
using WarehouseLib.Interfaces;
using WarehouseLib.Models;
using WarehouseLogic.Context;

namespace WarehouseLogic.Repositories
{
    public class MarcaRepository : IRepository<Marca>
    {
        private readonly SQLiteDbContext _dbContext;

        public MarcaRepository(SQLiteDbContext context)
        {
            _dbContext = context;
        }

        public void Add(Marca entity) => _dbContext.Add(entity);
        public void Delete(int id) => _dbContext.Remove(GetById(id));
        public void DeleteAll(IEnumerable<Marca> entities) => _dbContext.RemoveRange(entities);
        public ObservableCollection<Marca> GetAll() => _dbContext.Set<Marca>().Local.ToObservableCollection();
        public Marca GetById(int id) => _dbContext.Set<Marca>().Find(id);
        public void SaveChanges() => _dbContext.SaveChanges();
        public void Update(Marca entity) => _dbContext.Update(entity);
        public void UpdateAll(IEnumerable<Marca> entities) => _dbContext.UpdateRange(entities);
    }
}
