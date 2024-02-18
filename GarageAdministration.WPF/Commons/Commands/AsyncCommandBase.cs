﻿namespace GarageAdministration.WPF.Commons;

public abstract class AsyncCommandBase: CommandBase  
{
    public override async void Execute(object? parameter)
    {
        await ExecuteAsync(parameter);
    }

    protected abstract Task ExecuteAsync(object? parameter);
}