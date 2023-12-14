
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

        public Person CurrentPerson { get; set; } = new Person();


        // hämta hela listan
        public List<Person> GetPersonList()
        {
            var content = fileService.GetContentFromFile();

            if (content != null)
            {
                contentList = JsonConvert.DeserializeObject<List<Person>>(content)!;
      
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
        public bool RemovePerson(Person person)
        {

            

            if (!contentList.Contains(person))
            {
                return false;
            }
            else
            {

                contentList.Remove(person);
                fileService.SaveContentToFile(JsonConvert.SerializeObject(contentList));
                return true;
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
