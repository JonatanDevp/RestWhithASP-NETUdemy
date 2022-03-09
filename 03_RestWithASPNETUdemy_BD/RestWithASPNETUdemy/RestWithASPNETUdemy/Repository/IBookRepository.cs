using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository.Inplementations
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindById(long id);
        Book Update(Book book);
        void Delete(long id);
        List<Book> GetAll();
        bool Exists(long id);
    }
}
