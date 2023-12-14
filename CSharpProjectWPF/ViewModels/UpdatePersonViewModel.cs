

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpProject.Models;
using CSharpProject.Repositories;
using CSharpProjectWPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpProjectWPF.ViewModels;

public partial class UpdatePersonViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly PersonRepository _personRepository;

    [ObservableProperty]
    private Person _selectedPerson;

    [ObservableProperty]
    private Person _updatedPerson = new Person();


    public UpdatePersonViewModel(IServiceProvider sp, PersonRepository personRepository)
    {
        _sp = sp;
        _personRepository = personRepository;
        SelectedPerson = _personRepository.CurrentPerson;
    }





    [RelayCommand]
    private void NavigateToList()
    {
        _personRepository.RemovePerson(SelectedPerson);
        _personRepository.AddPerson(UpdatedPerson);
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<PersonListViewModel>();
    }
}
