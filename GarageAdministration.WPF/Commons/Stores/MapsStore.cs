using System.Collections;
using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;

namespace GarageAdministration.WPF.Commons.Stores;

public class MapsStore
{
    private readonly List<Map> _maps;
    private readonly ICreateCommand<Map> _createCommand;
    private readonly IUpdateCommand<Map> _updateCommand;
    private readonly IDeleteCommand _deleteCommand;
    private readonly IGetAllQuery<Map> _getAllQuery;

    public IEnumerable<Map> Maps => _maps;

    public event Action<Map>? MapAdded;
    public event Action<Map>? MapUpdated;
    public event Action? MapsLoaded;
    public event Action<int>? MapDeleted;
    
    public MapsStore(ICreateCommand<Map> createCommand, IUpdateCommand<Map> updateCommand, IDeleteCommand deleteCommand, IGetAllQuery<Map> getAllQuery)
    {
        _maps = new List<Map>();
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _deleteCommand = deleteCommand;
        _getAllQuery = getAllQuery;
    }

    public async Task Add(Map map)
    {
        await _createCommand.Execute(map);
        _maps.Add(map);
        MapAdded?.Invoke(map);
    }

    public async Task Update(Map map)
    {
        await _updateCommand.Execute(map);
        var index = _maps.FindIndex(g => g.Id == map.Id);
        if (index != -1)
        {
            _maps[index] = map;
        }
        MapUpdated?.Invoke(map);
    }

    public async Task Load()
    {
        var maps = await _getAllQuery.Execute();
        _maps.Clear();
        _maps.AddRange(maps);
        MapsLoaded?.Invoke();
    }

    public async Task Delete(int id)
    {
        await _deleteCommand.Execute(id);
        _maps.RemoveAll(g => g.Id == id);
        MapDeleted?.Invoke(id);
    }
}