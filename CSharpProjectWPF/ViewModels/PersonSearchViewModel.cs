

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpProject.Models;
using CSharpProject.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpProjectWPF.ViewModels;

public partial class PersonSearchViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly PersonRepository _personRepository;

    public PersonSearchViewModel(IServiceProvider sp, PersonRepository personRepository)
    {
        _sp = sp;
        _personRepository = personRepository;
    }

    [ObservableProperty]
    private string _email = null!;

    [ObservableProperty]
    private Person _foundPerson = new();

    [RelayCommand]

    private void Search()
    {
        FoundPerson = _personRepository.ShowPerson(Email);

    }

    [RelayCommand]
    private void NavigateToMainMenu()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
    }
}
