

using CSharpProject.Interfaces;
using CSharpProject.Models;
using CSharpProject.Repositories;
using CSharpProject.Services;
using Moq;

namespace CSharpProject.Tests
{
    public class MenuService_Tests 
    {
        [Fact]
        public void AddPersonMenuShould_AddPersonToList()
        {
            // Arrange
            var personRepositoryMock = new Mock<IPersonRepository>();
            var menuService = new MenuService(personRepositoryMock.Object);
           

            // Act
            menuService.AddPersonMenu();

            // Assert
            personRepositoryMock.Verify(repo => repo.AddPerson(It.IsAny<Person>()), Times.Once);
        }

        [Fact]
        public void CreateListMenuShould_CreateANewFile_WithListOfNames()
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

            //Assert
            List<Person> personsList = personRepository.GetPersonList();
            bool personExists = personsList.Any(p => p.Email == person.Email);
            Assert.True(personExists);
        }
        [Fact]
        public void DeletePersonMenuShould_DeletePersonFromList()
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
            personRepository.RemovePerson(email);

            //Assert
            List<Person> personsList = personRepository.GetPersonList();
            bool personExists = personsList.Any(p => p.Email == email);
            Assert.False(personExists); 
        }   
        [Fact]
        public void ShowAllMenuShould_ShowAllInList()
        {
            //Arrange
            PersonRepository personRepository = new PersonRepository();

            //Act
           List<Person> personList = personRepository.ShowAllPersons();  

            //Assert
            Assert.NotNull(personList);
        }
        [Fact]
        public void ShowPersonMenuShould_ShowSpecificPersonInList_UsingEmail()
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
            personRepository.ShowPerson(email);

            //Assert
            List<Person> personsList = personRepository.GetPersonList();
            bool personExists = personsList.Any(p => p.Email == email);
            Assert.True(personExists);
        }
    }
}
