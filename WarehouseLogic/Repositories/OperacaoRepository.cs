using System.Collections.Generic;
using System.Collections.ObjectModel;
using WarehouseLib.Interfaces;
using WarehouseLib.Models;
using WarehouseLogic.Context;

namespace WarehouseLogic.Repositories
{
    public class OperacaoRepository : IRepository<Operacao>
    {
        private readonly SQLiteDbContext _dbContext;

        public OperacaoRepository(SQLiteDbContext context)
        {
            _dbContext = context;
        }

        public void Add(Operacao entity) => _dbContext.Add(entity);
        public void Delete(int id) => _dbContext.Remove(GetById(id));
        public void DeleteAll(IEnumerable<Operacao> entities) => _dbContext.RemoveRange(entities);
        public ObservableCollection<Operacao> GetAll() => _dbContext.Set<Operacao>().Local.ToObservableCollection();
        public Operacao GetById(int id) => _dbContext.Set<Operacao>().Find(id);
        public void SaveChanges() => _dbContext.SaveChanges();
        public void Update(Operacao entity) => _dbContext.Update(entity);
        public void UpdateAll(IEnumerable<Operacao> entities) => _dbContext.UpdateRange(entities);
    }
}
