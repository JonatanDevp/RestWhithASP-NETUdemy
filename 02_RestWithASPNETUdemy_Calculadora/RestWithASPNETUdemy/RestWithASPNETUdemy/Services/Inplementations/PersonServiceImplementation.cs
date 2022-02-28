using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Inplementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Jonatan",
                LastName = "Lunardi",
                Address = "rua teste",
                Gender = "Male"
            };
        }

        public List<Person> GetAll()
        {
            List<Person> list = new List<Person>();
            for(int i=0; i<8; i++)
            {
                Person person = MockPerson(i);
                list.Add(person);
            }
            return list;
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person first Name" + i,
                LastName = "Person Last Name" + i,
                Address = "Some Address" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
