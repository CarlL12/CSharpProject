
using CSharpProject.Services;


namespace CSharpProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            MenuService menuService = new MenuService();

            menuService.ShowMeny();
            
        }
    }
}
