

namespace CSharpProject.Interfaces
{
    public interface IPerson
    {   
        /// <summary>
        /// First name of person
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Last name of person
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Email-adress for person
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Phone number of person
        /// </summary>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Adress of person
        /// </summary>

        string Adress { get; set; }

    }
}
