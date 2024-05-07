using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;

namespace GarageAdministration.WPF.Commons.Stores;

public class ContributionsStore
{
    private readonly List<Contribution> _contributions;
    private readonly ICreateCommand<Contribution> _createCommand;
    private readonly IUpdateCommand<Contribution> _updateCommand;
    private readonly IDeleteCommand _deleteCommand;
    private readonly IGetAllQuery<Contribution> _getAllQuery;

    public IEnumerable<Contribution> Contributions => _contributions;

    public event Action<Contribution>? ContributionAdded;
    public event Action<Contribution>? ContributionUpdated;
    public event Action? ContributionLoaded;
    public event Action<int>? ContributionDeleted;
    
    public ContributionsStore(ICreateCommand<Contribution> createCommand, IUpdateCommand<Contribution> updateCommand, IDeleteCommand deleteCommand, IGetAllQuery<Contribution> getAllQuery)
    {
        _contributions = new List<Contribution>();
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _deleteCommand = deleteCommand;
        _getAllQuery = getAllQuery;
    }

    public async Task Add(Contribution contribution)
    {
        await _createCommand.Execute(contribution);
        _contributions.Add(contribution);
        ContributionAdded?.Invoke(contribution);
    }

    public async Task Update(Contribution contribution)
    {
        await _updateCommand.Execute(contribution);
        var index = _contributions.FindIndex(c => c.Id == contribution.Id);
        if (index != -1)
        {
            _contributions[index] = contribution;
        }
        ContributionUpdated?.Invoke(contribution);
    }

    public async Task Load()
    {
        var contributions = await _getAllQuery.Execute();
        _contributions.Clear();
        _contributions.AddRange(contributions);
        ContributionLoaded?.Invoke();
    }

    public async Task Delete(int id)
    {
        await _deleteCommand.Execute(id);
        _contributions.RemoveAll(g => g.Id == id);
        ContributionDeleted?.Invoke(id);
    }
}