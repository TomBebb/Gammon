using ReactiveUI;

namespace Gammon.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _greeting = "Welcome!";

    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }
}
