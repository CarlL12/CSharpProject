
using CSharpProject.Interfaces;
using CSharpProject.Models;
using CSharpProject.Services;
using Newtonsoft.Json;
using System.Globalization;


namespace CSharpProject.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly FileService fileService = new FileService(@"D:\CSharpProjects\content.json");
        private List<Person> contentList = new List<Person>();
  


        // hämta hela listan
        public void GetPersonList()
        {
            var content = fileService.GetContentFromFile();

            if (content != null)
            {
                contentList = JsonConvert.DeserializeObject<List<Person>>(content)!;
            }

        }
        // lägga till person i listan
        public void AddPerson(Person person)
        {
            if (!contentList.Any(x => x.Email == person.Email))
            {
                contentList.Add(person);
                fileService.SaveContentToFile(JsonConvert.SerializeObject(contentList));
            }
            else
            {
                Console.WriteLine("Person already exists");
            }

        }
        // ta bort person ifrån listan
        public void RemovePerson(string email)
        {

            Person DeletePerson = contentList.Find(x => x.Email == email)!;

            if (DeletePerson == null)
            {
                Console.WriteLine("Could not find person");
            }
            else
            {
                Console.WriteLine($"{DeletePerson.FirstName} {DeletePerson.LastName} was deleted from the list.");

                contentList.Remove(DeletePerson);
                fileService.SaveContentToFile(JsonConvert.SerializeObject(contentList));
            }
        }


        // visa person i listan
        public void ShowPerson(string email)
        {

            Person personShow = contentList.Find(x => x.Email == email)!;

            if (personShow == null)
            {
                Console.WriteLine("Could not find person");
            }
            else
            {
                Console.WriteLine($"Förnamn:  {personShow.FirstName} ");
                Console.WriteLine($"Efternamn: {personShow.LastName} ");
                Console.WriteLine($"Email-adress: {personShow.Email} ");
                Console.WriteLine($"Phone number: {personShow.PhoneNumber} ");
                Console.WriteLine($"Adress: {personShow.Adress} ");
                Console.ReadKey();
            }


        }

        // visa alla i listan
        public void ShowAllPersons()
        {
            foreach (Person person in contentList)
            {
                Console.WriteLine($"Förnamn: {person.FirstName}");
                Console.WriteLine($"Efternamn: {person.LastName}");
                Console.WriteLine($"Email-adress: {person.Email}");
                Console.WriteLine($"Telefon nummer: {person.PhoneNumber}");
                Console.WriteLine($"Adress: {person.Adress}");
                Console.WriteLine("-------------");
            }
        }

        // Kollar ifall det finns en lista
        public bool HasPersonList()
        {
            var content = fileService.GetContentFromFile();
            return !string.IsNullOrEmpty(content);
        }

    }
}
