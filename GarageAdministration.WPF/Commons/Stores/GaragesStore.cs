using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;

namespace GarageAdministration.WPF.Commons.Stores;

public class GaragesStore
{
    private readonly List<Garage> _garages;
    private readonly ICreateCommand<Garage> _createCommand;
    private readonly IUpdateCommand<Garage> _updateCommand;
    private readonly IDeleteCommand _deleteCommand;
    private readonly IGetAllQuery<Garage> _getAllQuery;

    public IEnumerable<Garage> Garages => _garages;

    public event Action<Garage>? GarageAdded;
    public event Action<Garage>? GarageUpdated;
    public event Action? GaragesLoaded;
    public event Action<int>? GarageDeleted;

    public GaragesStore(ICreateCommand<Garage> createCommand, IUpdateCommand<Garage> updateCommand,
        IDeleteCommand deleteCommand, IGetAllQuery<Garage> getAllQuery)
    {
        _garages = new();
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _deleteCommand = deleteCommand;
        _getAllQuery = getAllQuery;
    }

    public async Task Add(Garage garage)
    {
        await _createCommand.Execute(garage);
        _garages.Add(garage);
        GarageAdded?.Invoke(garage);
    }

    public async Task Update(Garage garage)
    {
        await _updateCommand.Execute(garage);
        var index = _garages.FindIndex(g => g.Id == garage.Id);
        if (index != -1)
        {
            _garages[index] = garage;
        }
        GarageUpdated?.Invoke(garage);
    }

    public async Task Load()
    {
        var garages = await _getAllQuery.Execute();
        _garages.Clear();
        _garages.AddRange(garages);
        GaragesLoaded?.Invoke();
    }

    public async Task Delete(int id)
    {
        await _deleteCommand.Execute(id);
        _garages.RemoveAll(g => g.Id == id);
        GarageDeleted?.Invoke(id);
    }
}