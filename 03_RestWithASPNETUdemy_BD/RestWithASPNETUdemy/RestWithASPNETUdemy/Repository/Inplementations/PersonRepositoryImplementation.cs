using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Inplementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            this.context = context;
        }
        public Person FindById(long id)
        {
            try
            {
                return this.context.People.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> GetAll()
        {
            return this.context.People.ToList();
        }

        public Person Create(Person person)
        {
            try
            {
                this.context.Add(person);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = this.context.People.FirstOrDefault(x => x.Id == person.Id);

            if (result != null)
            {
                try
                {
                    this.context.Entry(result).CurrentValues.SetValues(person);
                    this.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = this.context.People.FirstOrDefault(x => x.Id == id);
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
                     
        public bool Exists(long id)
        {
            var person = this.context.People.Any(x => x.Id.Equals(id));
            return this.context.People.Any(x => x.Id.Equals(id));
        }
    }
}
