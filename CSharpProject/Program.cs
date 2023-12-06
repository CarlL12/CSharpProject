
using CSharpProject.Repositories;
using CSharpProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSharpProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<MenuService>();
                services.AddSingleton<PersonRepository>();
            }).Build();

            builder.Start();
            Console.Clear();
            var menuservice = builder.Services.GetService<MenuService>()!;
            menuservice.ShowMeny();
            
        }
    }
}
