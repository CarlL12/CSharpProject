

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpProject.Models;
using CSharpProject.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace CSharpProjectWPF.ViewModels;

public partial class PersonAddViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly PersonRepository _personRepository;

    [ObservableProperty]
    private Person _personForm = new();

    [ObservableProperty]

    private ObservableCollection<Person> _personList = [];


    public PersonAddViewModel(IServiceProvider sp, PersonRepository personRepository)
    {
        _sp = sp;
        _personRepository = personRepository;
        UpdateProductList();

    }



    [RelayCommand]
    private void NavigateToMainMenu()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
    }

    [RelayCommand]

    private void AddProductTolist()
    {

        if (PersonForm.FirstName != null)
        {
            _personRepository.AddPerson(PersonForm);
            PersonForm = new();


        }


    }
    public void UpdateProductList()
    {
        PersonList = new ObservableCollection<Person>(_personRepository.GetPersonList().Select(product => new Person()).ToList());
    }
}
