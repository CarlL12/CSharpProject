
using CSharpProject.Interfaces;
using CSharpProject.Models;
using CSharpProject.Repositories;

namespace CSharpProject.Services;

public class MenuService : IMenuService
{

    
    PersonRepository personRepository = new PersonRepository();


    public void ShowMeny()
    {
        //kollar ifall det redan finns en lista som heter content.json annars skapar vi en ny

        if (!personRepository.HasPersonList())
        {
            CreateListMenu();
        }
        // kör igenom menyn
        while (true)
        {
            personRepository.GetPersonList();
            Console.Clear();
            Console.WriteLine("1. Lägga till en person?");
            Console.WriteLine("2. Visa en specifik person?");
            Console.WriteLine("3. Ta bort en person?");
            Console.WriteLine("4. Visa alla personer?");
            Console.Write("");

            int option = int.Parse(Console.ReadLine()!);
            Console.Clear();
            switch (option)
            {
                case 1:
                    AddPersonMenu();
                    break;
                case 2:
                    ShowPersonMenu();
                    break;
                case 3:
                    DeletePersonMenu();
                    break;
                case 4:
                    ShowAllMenu();
                    break;

            }
            Console.ReadKey();
        }
    }

    // Menyn som kommer upp ifall vi inte har någon lista ifrån början
    public void CreateListMenu()
    {

        Console.WriteLine("Välkommen! Du måste skapa en person för att använda programmet ");
        Person person = new Person();
        Console.Write("Förnamn:");
        person.FirstName = Console.ReadLine()!;
        Console.Write("Efternamn:");
        person.LastName = Console.ReadLine()!;
        Console.Write("Email-address:");
        person.Email = Console.ReadLine()!;
        Console.Write("Telefon-nummer :");
        person.PhoneNumber = Console.ReadLine()!;
        Console.Write("Adress :");
        person.Adress = Console.ReadLine()!;
        personRepository.AddPerson(person);
        Console.Clear();
        Console.WriteLine("Person skapad! Tryck på valfri knapp för att komma till meny.");
        Console.ReadKey();
    }
    //lägger till en person i listan
    public void AddPersonMenu()
    {
        Person person = new Person();
        Console.Write("Förnamn:");
        person.FirstName = Console.ReadLine()!;
        Console.Write("Efternamn:");
        person.LastName = Console.ReadLine()!;
        Console.Write("Email-address:");
        person.Email = Console.ReadLine()!;
        Console.Write("Telefon-nummer :");
        person.PhoneNumber = Console.ReadLine()!;
        Console.Write("Adress :");
        person.Adress = Console.ReadLine()!;
        personRepository.AddPerson(person);
        Console.Clear();
        Console.WriteLine($"La till {person.FirstName} {person.LastName} i listan!");
        Console.WriteLine("Tryck på valfri knapp för att komma till meny.");
    }
    // visar en specifik person
    public void ShowPersonMenu()
    {
        Console.Write("Ange email-adress på den du vill hitta: ");
        string email = Console.ReadLine()!;
        Console.Clear();
        var personShow = personRepository.ShowPerson(email);
        if (personShow == null)
        {
            Console.WriteLine("Kunde inte hitta person");
        }
        else
        {
            Console.WriteLine($"Förnamn:  {personShow.FirstName} ");
            Console.WriteLine($"Efternamn: {personShow.LastName} ");
            Console.WriteLine($"Email-adress: {personShow.Email} ");
            Console.WriteLine($"Telefon-nummer: {personShow.PhoneNumber} ");
            Console.WriteLine($"Adress: {personShow.Adress} ");

        }
        Console.WriteLine("Tryck på valfri knapp för att komma till meny.");
    }
    // visar alla personer i listan
    public void ShowAllMenu()
    {
        List<Person> contentList = personRepository.ShowAllPersons();
        foreach (Person person in contentList)
        {
            Console.WriteLine($"Förnamn: {person.FirstName}");
            Console.WriteLine($"Efternamn: {person.LastName}");
            Console.WriteLine($"Email-adress: {person.Email}");
            Console.WriteLine($"Telefon nummer: {person.PhoneNumber}");
            Console.WriteLine($"Adress: {person.Adress}");
            Console.WriteLine("-------------");
        }
        Console.WriteLine("Tryck på valfri knapp för att komma till meny.");
    }
    // tar bort en person ifrån listan
    public void DeletePersonMenu()
    {
        Console.Write("Ange email-adress på den du vill ta bort: ");
        string email = Console.ReadLine()!;
        Person person = new Person();
        person.Email = email;
        Console.Clear();
        personRepository.RemovePerson(person);
        Console.WriteLine("Tryck på valfri knapp för att komma till meny.");
    }
}
