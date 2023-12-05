
using CSharpProject.Interfaces;

namespace CSharpProject.Models;

public class Person : IPerson
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Adress { get; set; } = null!;

    public Person()
    {

    }

    public Person(string firstName, string lastName, string email, string phoneNumber, string adress)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Adress = adress;
    }
}
