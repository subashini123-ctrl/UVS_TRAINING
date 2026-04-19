using PersonalExpenseApp.Models;
using PersonalExpenseApp.ViewModels;
using PersonalExpenseApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalExpenseApp.ViewModels;

public class CategoryViewModel

{
    private readonly DatabaseService _db;

    public ObservableCollection<Category> Categories { get; set; } = new();

    public string Name { get; set; }
    public string Emoji { get; set; }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    public CategoryViewModel(DatabaseService db)
    {
        _db = db;

        AddCommand = new Command(async () => await AddCategory());
        DeleteCommand = new Command<Category>(async (c) => await DeleteCategory(c));

        Load();
    }

    public async void Load()
    {
        var list = await _db.GetCategories();
        Categories.Clear();

        foreach (var item in list)
            Categories.Add(item);
    }

    private async Task AddCategory()
    {
        if (string.IsNullOrWhiteSpace(Name)) return;

        var cat = new Category
        {
            Name = Name,
            
        };

        await _db.AddCategory(cat);

        Name = "";
        

        Load(); 
    }

    private async Task DeleteCategory(Category cat)
    {
        await _db.DeleteCategory(cat);
        Load(); 
    }
}
    
    

