using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Inplementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private IRepository<Book> Repository;
        private readonly BookConverter converter;
        public BookBusinessImplementation(IRepository<Book> Repository)
        {
            this.Repository = Repository;
            this.converter = new BookConverter();
        }
        public BookVO Create(BookVO book)
        {
            var bookEntity = this.converter.Parse(book);
            bookEntity = this.Repository.Create(bookEntity);
            return this.converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            this.Repository.Delete(id);
        }

        public BookVO FindById(long id) 
        {
            return this.converter.Parse(this.Repository.FindById(id));
        }

        public List<BookVO> GetAll()
        {
            return this.converter.Parse(this.Repository.GetAll());
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = this.converter.Parse(book);
            bookEntity = this.Repository.Update(bookEntity);
            return this.converter.Parse(bookEntity);
        }
    }
}
