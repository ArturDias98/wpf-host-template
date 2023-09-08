using HostTemplate.Options;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HostTemplate;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string _userName = string.Empty;
    private string _email = string.Empty;
    private readonly AccountSettings _accountSettings;

    public MainWindow(IOptions<AccountSettings> options)
    {
        _accountSettings = options.Value;

        InitializeComponent();

        DataContext = this;

        UpdateUI();
    }

    private void UpdateUI()
    {
        UserName = _accountSettings.UserName;
        Email = _accountSettings.Email;
    }

    public string UserName
    {
        get { return _userName; }
        set
        {
            _userName = value;
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get { return _email; }
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
