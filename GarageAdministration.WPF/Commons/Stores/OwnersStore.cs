using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;

namespace GarageAdministration.WPF.Commons.Stores;

public class OwnersStore
{
    private readonly List<Owner> _owners;
    private readonly ICreateCommand<Owner> _createCommand;
    private readonly IUpdateCommand<Owner> _updateCommand;
    private readonly IDeleteCommand _deleteCommand;
    private readonly IGetAllQuery<Owner> _getAllOwnersQuery;

    public IEnumerable<Owner> Owners => _owners;

    public event Action<Owner>? OwnerAdded; 
    public event Action<Owner>? OwnerUpdated;
    public event Action<int>? OwnerDeleted;
    public event Action OwnersLoaded;

    public OwnersStore(ICreateCommand<Owner> createCommand, IUpdateCommand<Owner> updateCommand,
        IDeleteCommand deleteCommand, IGetAllQuery<Owner> getAllOwnersQuery)
    {
        _owners = new();
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _deleteCommand = deleteCommand;
        _getAllOwnersQuery = getAllOwnersQuery;
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

    public async Task Load()
    {
        var owners = await _getAllOwnersQuery.Execute();
        
        _owners.Clear();
        _owners.AddRange(owners);
        
        OwnersLoaded?.Invoke();
    }
}