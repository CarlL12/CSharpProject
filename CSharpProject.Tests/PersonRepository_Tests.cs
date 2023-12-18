using CSharpProject.Interfaces;
using CSharpProject.Models;
using CSharpProject.Repositories;
using CSharpProject.Services;
using Newtonsoft.Json;


namespace CSharpProject.Tests
{
    public class PersonRepository_Tests
    {
        [Fact]
        public void AddPersonShould_AddPersonToList() 
        {
            //Arrange
            PersonRepository personrepository = new PersonRepository();

            Person person = new Person
            {
                Adress = "Lövhammar",
                Email = "carl@domain.com",
                PhoneNumber = "072314710",
                FirstName = "Carl",
                LastName = "Lindqvist"

            };
            //Act
            personrepository.AddPerson(person);

            //Assert
            List<Person> contentList = personrepository.GetPersonList();
            bool personExists = contentList.Any(p => p.Email == person.Email);
            Assert.True(personExists);

        }
        [Fact]
        public void GetPersonListShould_GetListFromComputer_AndReturnList()
        {
            //Arrange
            PersonRepository personRepository = new PersonRepository();


            //Act
            List<Person> contentList = personRepository.GetPersonList();

            
            //Assert
            Assert.NotEmpty(contentList);
            
        }   
        [Fact]
        public void HasPersonListShould_ReturnListIfListExists()
        {
            //Arrange
            PersonRepository personRepository = new PersonRepository();
            //Act
            bool content = personRepository.HasPersonList();
            //Assert
            Assert.True(content);
        }
        [Fact]
        public void RemovePersonShould_RemovePersonFromList_AndSaveFile()
        {
            //Arrange
            PersonRepository personRepository = new PersonRepository();
            Person person = new Person 
            {
                Adress = "Lövhammar",
                Email = "carl@domain.com",
                PhoneNumber = "072314710",
                FirstName = "Carl",
                LastName = "Lindqvist"
            };

            
            //Act
            personRepository.AddPerson(person);
            personRepository.RemovePerson(person);
            //Assert
            List<Person> content = personRepository.GetPersonList();
            bool personExists = content.Any(p => p.Email == person.Email);
            Assert.False(personExists);
        }
        [Fact]
        public void ShowAllPersonsShould_ShowAllPersonsInList()
        {
            //Arrange
            PersonRepository personRepository = new PersonRepository();
            //Act
            List<Person> personList = personRepository.ShowAllPersons();

            //Assert
            Assert.NotNull(personList);
        }
        [Fact]
        public void ShowPersonShould_ReturnPerson_WithMatchingEmail ()
        {
            //Arrange
            PersonRepository personRepository = new PersonRepository();
            Person person = new Person
            {
                Adress = "Lövhammar",
                Email = "carl@domain.com",
                PhoneNumber = "072314710",
                FirstName = "Carl",
                LastName = "Lindqvist"
            };
            string email = "carl@domain.com";
            //Act
            personRepository.AddPerson(person);
            Person newperson = personRepository.ShowPerson(email);
            //Assert
            Assert.Equal(email,newperson.Email);
        }
    }
}
