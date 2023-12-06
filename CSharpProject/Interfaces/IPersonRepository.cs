using CSharpProject.Models;

namespace CSharpProject.Interfaces
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
        List<Person> GetPersonList();
        bool HasPersonList();
        void RemovePerson(string email);
        List<Person> ShowAllPersons();
        Person ShowPerson(string email);


    }
}