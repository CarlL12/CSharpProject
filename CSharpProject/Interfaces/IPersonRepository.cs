using CSharpProject.Models;

namespace CSharpProject.Interfaces
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
        void GetPersonList();
        bool HasPersonList();
        void RemovePerson(string email);
        void ShowAllPersons();
        void ShowPerson(string email);


    }
}