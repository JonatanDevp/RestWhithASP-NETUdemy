using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Inplementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IRepository<Person> Repository;
        private readonly PersonConverter converter;

        public PersonBusinessImplementation(IRepository<Person> Repository)
        {
            this.Repository = Repository;
            this.converter = new PersonConverter();
        }
        public PersonVO FindById(long id)
        {
            return this.converter.Parse(this.Repository.FindById(id));
        }

        public List<PersonVO> GetAll()
        {
            return this.converter.Parse(this.Repository.GetAll());
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = this.converter.Parse(person);
            personEntity = this.Repository.Create(personEntity);
            return this.converter.Parse(personEntity);
        }
        public PersonVO Update(PersonVO person)
        {
            var personEntity = this.converter.Parse(person);
            var entity = this.Repository.Update(personEntity);
            return this.converter.Parse(entity);
        }

        public void Delete(long id)
        {
            Repository.Delete(id);
        }       
    }
}
