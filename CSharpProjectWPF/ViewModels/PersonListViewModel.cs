

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpProject.Models;
using CSharpProject.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace CSharpProjectWPF.ViewModels;

public partial class PersonListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly PersonRepository _personRepository;

    public PersonListViewModel(IServiceProvider sp, PersonRepository personRepository)
    {
        _sp = sp;
        _personRepository = personRepository;
        UpdateProductList();
    }

    [ObservableProperty]

    private ObservableCollection<Person> _personList = [];
    [ObservableProperty]
    private Person person = new Person();


    [RelayCommand]
    private void NavigateToMainMenu()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
    }

    [RelayCommand]
    private void NavigateToUpdateProduct(Person person)
    {
        _personRepository.CurrentPerson = person;

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<UpdatePersonViewModel>();

    }

    [RelayCommand]
    public void RemoveProductFromList(Person person)
    {
        if (person != null)
        {
            _personRepository.RemovePerson(person);
            UpdateProductList();
        }
    }
    public void UpdateProductList()
    {
        PersonList = new ObservableCollection<Person>(_personRepository.GetPersonList());
    }

}
