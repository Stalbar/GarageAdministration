using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.WPF.Commons.Stores;

public class PositionsStore
{
    private readonly List<Position> _positions;
    private readonly ICreateCommand<Position> _createCommand;
    private readonly IUpdateCommand<Position> _updateCommand;
    private readonly IDeleteCommand _deleteCommand;

    public IEnumerable<Position> Positions => _positions;

    public event Action<Position>? PositionAdded;
    public event Action<Position>? PositionUpdated;
    public event Action<int>? PositionDeleted;

    public PositionsStore(ICreateCommand<Position> createCommand, IUpdateCommand<Position> updateCommand, IDeleteCommand deleteCommand)
    {
        _positions = new();
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _deleteCommand = deleteCommand;
    }

    public async Task Add(Position position)
    {
        await _createCommand.Execute(position);
        _positions.Add(position);
        PositionAdded?.Invoke(position);
    }

    public async Task Update(Position position)
    {
        await _updateCommand.Execute(position);
        var index = _positions.FindIndex(p => p.Id == position.Id);
        if (index != -1)
        {
            _positions[index] = position;
        }
        PositionUpdated?.Invoke(position);
    }

    public async Task Delete(int id)
    {
        await _deleteCommand.Execute(id);
        _positions.RemoveAll(p => p.Id == id);
        PositionDeleted?.Invoke(id);
    }
}