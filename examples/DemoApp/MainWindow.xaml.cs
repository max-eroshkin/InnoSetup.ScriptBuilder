namespace DemoApp;

using System.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CloseButtonOnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}