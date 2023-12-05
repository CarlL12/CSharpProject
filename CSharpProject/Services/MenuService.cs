
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
                    ShowAllMenu();
                    break;
                case 4:
                    DeletePersonMenu();
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
        Console.Write("Email-addres:");
        person.Email = Console.ReadLine()!;
        Console.Write("Telefon nummer :");
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
        Console.Write("Email-addres:");
        person.Email = Console.ReadLine()!;
        Console.Write("Telefon nummer :");
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
        personRepository.ShowPerson(email);
        Console.WriteLine("Tryck på valfri knapp för att komma till meny.");
    }
    // visar alla personer i listan
    public void ShowAllMenu()
    {
        personRepository.ShowAllPersons();
        Console.WriteLine("Tryck på valfri knapp för att komma till meny.");
    }
    // tar bort en person ifrån listan
    public void DeletePersonMenu()
    {
        Console.Write("Ange email-adress på den du vill ta bort: ");
        string email = Console.ReadLine()!;
        Console.Clear();
        personRepository.RemovePerson(email);
        Console.WriteLine("Tryck på valfri knapp för att komma till meny.");
    }
}
