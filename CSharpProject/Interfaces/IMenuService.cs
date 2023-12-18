using CSharpProject.Models;

namespace CSharpProject.Interfaces
{
    public interface IMenuService
    {   
        /// <summary>
        /// Menu for adding person
        /// </summary>
        void AddPersonMenu();
        /// <summary>
        /// Menu for creating list
        /// </summary>
        void CreateListMenu();

        /// <summary>
        /// Menu to show
        /// </summary>
        void ShowMeny();

        /// <summary>
        /// Show specific person menu
        /// </summary>
        void ShowPersonMenu();

        /// <summary>
        /// Show all in list menu
        /// </summary>

        void ShowAllMenu();

        /// <summary>
        /// Menu for deleting person
        /// </summary>

        void DeletePersonMenu();

    }
}