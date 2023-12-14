using CSharpProject.Models;

namespace CSharpProject.Interfaces
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
        List<Person> GetPersonList();
        bool HasPersonList();
        bool RemovePerson(Person person);
        List<Person> ShowAllPersons();
        Person ShowPerson(string email);


    }
}