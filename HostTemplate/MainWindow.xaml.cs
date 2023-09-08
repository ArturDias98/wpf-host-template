using HostTemplate.Options;
using Microsoft.Extensions.Options;
using System.Windows;

namespace HostTemplate;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly AccountSettings _accountSettings;

    public MainWindow(IOptions<AccountSettings> options)
    {
        _accountSettings = options.Value;

        InitializeComponent();
    }
}
