
using CSharpProject.Repositories;
using CSharpProjectWPF.ViewModels;
using CSharpProjectWPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CSharpProjectWPF;


public partial class App : Application
{
    private IHost? _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<PersonRepository>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddTransient<MainMenuView>();
                services.AddTransient<MainMenuViewModel>();
                services.AddTransient<PersonListViewModel>();
                services.AddTransient<PersonListView>();
                services.AddTransient<PersonAddViewModel>();
                services.AddTransient<PersonAddView>();
                services.AddTransient<UpdatePersonViewModel>();
                services.AddTransient<UpdatePersonView>();
                services.AddTransient<PersonSearchViewModel>();
                services.AddTransient<PersonSearchView>();


            })
           .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host!.Start();

        var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}

