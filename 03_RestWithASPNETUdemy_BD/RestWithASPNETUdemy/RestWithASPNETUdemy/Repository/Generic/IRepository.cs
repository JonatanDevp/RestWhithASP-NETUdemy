using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity 
    {
        T Create(T person);
        T FindById(long id);
        T Update(T person);
        void Delete(long id);
        List<T> GetAll();
        bool Exists(long id);
    }
}
