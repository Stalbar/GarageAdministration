using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;

namespace GarageAdministration.WPF.Commons.Stores;

public class GarageBlockStore
{
    private readonly List<GarageBlock> _garageBlocks;
    private readonly ICreateCommand<GarageBlock> _createCommand;
    private readonly IUpdateCommand<GarageBlock> _updateCommand;
    private readonly IDeleteCommand _deleteCommand;
    private readonly IGetAllQuery<GarageBlock> _getAllQuery;

    public IEnumerable<GarageBlock> GarageBlocks => _garageBlocks;

    public event Action<GarageBlock>? GarageBlockAdded;
    public event Action<GarageBlock>? GarageBlockUpdated;
    public event Action? GarageBlocksLoaded;
    public event Action<int>? GarageBlockDeleted;

    public GarageBlockStore(ICreateCommand<GarageBlock> createCommand, IUpdateCommand<GarageBlock> updateCommand, IDeleteCommand deleteCommand, IGetAllQuery<GarageBlock> getAllQuery)
    {
        _garageBlocks = new List<GarageBlock>();
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _deleteCommand = deleteCommand;
        _getAllQuery = getAllQuery;
    }

    public async Task Add(GarageBlock garageBlock)
    {
        await _createCommand.Execute(garageBlock);
        _garageBlocks.Add(garageBlock);
        GarageBlockAdded?.Invoke(garageBlock);
    }

    public async Task Update(GarageBlock garageBlock)
    {
        await _updateCommand.Execute(garageBlock);
        var index = _garageBlocks.FindIndex(g => g.Id == garageBlock.Id);
        if (index != -1)
        {
            _garageBlocks[index] = garageBlock;
            GarageBlockUpdated?.Invoke(garageBlock);
        }
    }

    public async Task Load()
    {
        var garageBlocks = await _getAllQuery.Execute();
        _garageBlocks.Clear();
        _garageBlocks.AddRange(garageBlocks);
        GarageBlocksLoaded?.Invoke();
    }

    public async Task Delete(int id)
    {
        await _deleteCommand.Execute(id);
        _garageBlocks.RemoveAll(g => g.Id == id);
        GarageBlockDeleted?.Invoke(id);
    }
}