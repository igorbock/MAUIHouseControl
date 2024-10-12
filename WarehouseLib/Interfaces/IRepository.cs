using System.Collections.ObjectModel;

namespace WarehouseLib.Interfaces
{
    public interface IRepository<TypeT> where TypeT : class
    {
        void Add(TypeT entity);
        ObservableCollection<TypeT> GetAll();
        TypeT GetById(int id);
        void Update(TypeT entity);
        void Delete(int id);
        void SaveChanges();
    }
}
