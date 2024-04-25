using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;

namespace GarageAdministration.WPF.Commons.Stores;

public class GarageMapInfoStore
{
    private readonly List<GarageMapInfo> _mapInfos;
    private readonly ICreateCommand<GarageMapInfo> _createCommand;
    private readonly IUpdateCommand<GarageMapInfo> _updateCommand;
    private readonly IDeleteCommand _deleteCommand;
    private readonly IGetAllQuery<GarageMapInfo> _getAllMapInfosQuery;

    public IEnumerable<GarageMapInfo> MapInfos => _mapInfos;

    public event Action<GarageMapInfo>? PositionAdded;
    public event Action<GarageMapInfo>? PositionUpdated;
    public event Action<int>? PositionDeleted;
    public event Action MapInfosLoaded;
    
    public GarageMapInfoStore(ICreateCommand<GarageMapInfo> createCommand, IUpdateCommand<GarageMapInfo> updateCommand, IDeleteCommand deleteCommand, IGetAllQuery<GarageMapInfo> getAllMapInfosQuery)
    {
        _mapInfos = new List<GarageMapInfo>();
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _deleteCommand = deleteCommand;
        _getAllMapInfosQuery = getAllMapInfosQuery;
    }

    public async Task Add(GarageMapInfo position)
    {
        await _createCommand.Execute(position);
        _mapInfos.Add(position);
        PositionAdded?.Invoke(position);
    }

    public async Task Update(GarageMapInfo position)
    {
        await _updateCommand.Execute(position);
        var index = _mapInfos.FindIndex(p => p.Id == position.Id);
        if (index != -1)
        {
            _mapInfos[index] = position;
        }
        PositionUpdated?.Invoke(position);
    }

    public async Task Delete(int id)
    {
        await _deleteCommand.Execute(id);
        _mapInfos.RemoveAll(p => p.Id == id);
        PositionDeleted?.Invoke(id);
    }

    public async Task Load()
    {
        var mapInfos = await _getAllMapInfosQuery.Execute();
        
        _mapInfos.Clear();
        _mapInfos.AddRange(mapInfos);
        
        MapInfosLoaded?.Invoke();
    }
}