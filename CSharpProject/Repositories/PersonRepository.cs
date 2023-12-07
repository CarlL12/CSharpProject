
using CSharpProject.Interfaces;
using CSharpProject.Models;
using CSharpProject.Services;
using Newtonsoft.Json;



namespace CSharpProject.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly FileService fileService = new FileService(@"D:\CSharpProjects\content.json");

         // skapar lista för att lagra personer i
        private List<Person> contentList = new List<Person>();
 

        // hämta hela listan
        public List<Person> GetPersonList()
        {
            var content = fileService.GetContentFromFile();

            if (content != null)
            {
                contentList = JsonConvert.DeserializeObject<List<Person>>(content)!;
      
            }
            else
            {
                contentList = new List<Person>();
            }
            return contentList;
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
                Console.WriteLine("Personen finns redan!");
            }

        }
        // ta bort person ifrån listan
        public void RemovePerson(string email)
        {

            Person DeletePerson = contentList.Find(x => x.Email == email)!;

            if (DeletePerson == null)
            {
                Console.WriteLine("Kunda inte hitta person!");
            }
            else
            {
                Console.WriteLine($"{DeletePerson.FirstName} {DeletePerson.LastName} togs bort ifrån listan.");

                contentList.Remove(DeletePerson);
                fileService.SaveContentToFile(JsonConvert.SerializeObject(contentList));
            }
        }


        // Retunerar en person i listan
        public Person ShowPerson(string email)
        {

            Person personShow = contentList.Find(x => x.Email == email)!;
            return personShow ??= null!;

        }

        // Retunerar hela listan
        public List<Person> ShowAllPersons()
        {


            return contentList ??= null!;
        }

        // Kollar ifall det finns en lista
        public bool HasPersonList()
        {
            var content = fileService.GetContentFromFile();
            return !string.IsNullOrEmpty(content);
        }

    }
}
