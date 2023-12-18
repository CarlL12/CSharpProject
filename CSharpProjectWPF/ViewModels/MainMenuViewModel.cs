

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpProject.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpProjectWPF.ViewModels;

public partial class MainMenuViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly PersonRepository _personRepository;

    public MainMenuViewModel(IServiceProvider sp, PersonRepository personRepository)
    {
        _sp = sp;
        _personRepository = personRepository;
    }

    [RelayCommand]
    private void NavigateToList()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<PersonListViewModel>();
    }

    [RelayCommand]
    private void NavigateToAdd()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<PersonAddViewModel>();
    }

    [RelayCommand]
    private void NavigateToSearch()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<PersonSearchViewModel>();
    }

}
