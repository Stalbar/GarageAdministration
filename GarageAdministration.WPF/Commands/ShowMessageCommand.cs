using GarageAdministration.WPF.Commons;
using Xceed.Wpf.Toolkit;

namespace GarageAdministration.WPF.Commands;

public class ShowMessageCommand: CommandBase
{
    private readonly string _message;

    public ShowMessageCommand(string message)
    {
        _message = message;
    }

    public override void Execute(object? parameter)
    {
        MessageBox.Show(_message);
    }
}