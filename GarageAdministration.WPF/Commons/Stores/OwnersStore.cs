using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.WPF.Commons.Stores;

public class OwnersStore
{
    private readonly List<Owner> _owners;
    private readonly ICreateCommand<Owner> _createCommand;
    private readonly IUpdateCommand<Owner> _updateCommand;
    private readonly IDeleteCommand _deleteCommand;

    public IEnumerable<Owner> Owners => _owners;

    public event Action<Owner>? OwnerAdded; 
    public event Action<Owner>? OwnerUpdated;
    public event Action<int>? OwnerDeleted;

    public OwnersStore(ICreateCommand<Owner> createCommand, IUpdateCommand<Owner> updateCommand,
        IDeleteCommand deleteCommand)
    {
        _owners = new();
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _deleteCommand = deleteCommand;
    }

    public async Task Add(Owner owner)
    {
        await _createCommand.Execute(owner);
        _owners.Add(owner);
        OwnerAdded?.Invoke(owner);
    }

    public async Task Update(Owner owner)
    {
        await _updateCommand.Execute(owner);
        var index = _owners.FindIndex(o => o.Id == owner.Id);
        if (index != -1)
        {
            _owners[index] = owner;
        }
        OwnerUpdated?.Invoke(owner);
    }

    public async Task Delete(int id)
    {
        await _deleteCommand.Execute(id);
        _owners.RemoveAll(o => o.Id == id);
        OwnerDeleted?.Invoke(id);
    }
}