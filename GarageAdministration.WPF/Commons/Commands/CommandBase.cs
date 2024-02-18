using System.Windows.Input;

namespace GarageAdministration.WPF.Commons;

public abstract class CommandBase: ICommand
{
    public virtual bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;

    protected virtual void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}