using CSharpProject.Models;

namespace CSharpProject.Interfaces
{
    public interface IPersonRepository
    {   
        /// <summary>
        /// Adding person to list
        /// </summary>
        /// <param name="person"></param>
        void AddPerson(Person person);
        /// <summary>
        /// Getting list file on comp 
        /// </summary>
        /// <returns></returns>
        List<Person> GetPersonList();

        /// <summary>
        /// Returns a bool if file exists on comp
        /// </summary>
        /// <returns></returns>
        bool HasPersonList();

        /// <summary>
        /// Removes person on list
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        bool RemovePerson(Person person);

        /// <summary>
        /// Returns the list
        /// </summary>
        /// <returns></returns>
        List<Person> ShowAllPersons();

        /// <summary>
        /// Returns one person on the list
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Person ShowPerson(string email);


    }
}