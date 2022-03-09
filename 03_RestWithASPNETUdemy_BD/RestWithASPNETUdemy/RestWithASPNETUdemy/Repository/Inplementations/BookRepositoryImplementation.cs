using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Inplementations;

namespace RestWithASPNETUdemy.Repository
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            this.context = context;
        }
        public Book Create(Book book)
        {
            try
            {
                this.context.Add(book);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return book;
        }

        public List<Book> GetAll()
        {
            return this.context.Books.ToList();
        }

        public Book FindById(long id)
        {
            try
            {
                return this.context.Books.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(long id)
        {
            var result = this.context.Books.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                try
                {
                    this.context.Remove(result);
                    this.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = this.context.Books.FirstOrDefault(x => x.Id == book.Id);

            if (result != null)
            {
                try
                {
                    this.context.Entry(result).CurrentValues.SetValues(book);
                    this.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return book;
        }
        public bool Exists(long id)
        {
            return this.context.Books.Any(x => x.Id.Equals(id));
        }
    }
}
