using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Inplementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IPersonRepository repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            this.repository = repository;
        }
        public Person FindById(long id)
        {
            return this.repository.FindById(id);
        }

        public List<Person> GetAll()
        {
            return this.repository.GetAll();
        }

        public Person Create(Person person)
        {
            return this.repository.Create(person);
        }
        public Person Update(Person person)
        {
            return repository.Update(person);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }       
    }
}
