using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;

namespace GarageAdministration.WPF.Commons.Stores;

public class ReportsStore
{
    private readonly List<Report> _reports;
    private readonly ICreateCommand<Report> _createCommand;
    private readonly IDeleteCommand _deleteCommand;
    private readonly IGetAllQuery<Report> _getAllQuery;

    public event Action<Report>? ReportAdded;
    public event Action? ReportsLoaded;
    public event Action<int>? ReportDeleted; 
    
    public ReportsStore(ICreateCommand<Report> createCommand, IDeleteCommand deleteCommand, IGetAllQuery<Report> getAllQuery)
    {
        _reports = new List<Report>();
        _createCommand = createCommand;
        _deleteCommand = deleteCommand;
        _getAllQuery = getAllQuery;
    }

    public async Task Add(Report report)
    {
        await _createCommand.Execute(report);
        _reports.Add(report);
        ReportAdded?.Invoke(report);
    }

    public async Task Load()
    {
        var reports = await _getAllQuery.Execute();
        _reports.Clear();
        _reports.AddRange(reports);
        ReportsLoaded?.Invoke();
    }

    public async Task Delete(int id)
    {
        await _deleteCommand.Execute(id);
        _reports.RemoveAll(r => r.Id == id);
        ReportDeleted?.Invoke(id);
    }
}