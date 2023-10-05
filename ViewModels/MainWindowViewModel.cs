using Gammon.Db;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace Gammon.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private GamesContext _gamesContext = GamesContext.AutoCreate();
    private string _greeting = "Welcome!";

    public DbSet<Game> Games => _gamesContext.Games;

    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }
}