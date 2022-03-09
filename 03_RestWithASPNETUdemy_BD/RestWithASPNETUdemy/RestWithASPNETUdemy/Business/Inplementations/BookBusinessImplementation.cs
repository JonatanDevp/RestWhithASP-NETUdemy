using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Inplementations;

namespace RestWithASPNETUdemy.Business.Inplementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private IBookRepository repository;
        public BookBusinessImplementation(IBookRepository repository)
        {
            this.repository = repository;
        }
        public Book Create(Book book)
        {
            return this.repository.Create(book);
        }

        public void Delete(long id)
        {
            this.repository.Delete(id);
        }

        public Book FindById(long id) 
        {
            return this.repository.FindById(id);
        }

        public List<Book> GetAll()
        {
            return this.repository.GetAll();
        }

        public Book Update(Book book)
        {
            return this.repository.Update(book);
        }
    }
}
