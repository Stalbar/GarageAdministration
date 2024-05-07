using GarageAdministration.Domain.Commands;

namespace GarageAdministration.EF.Commands;

public class DeleteReportCommand: IDeleteCommand
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public DeleteReportCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(int id)
    {
        await using var context = _contextFactory.Create();
        var reportDto = context.Reports.FirstOrDefault(r => r.Id == id)!;
        context.Reports.Remove(reportDto);
        await context.SaveChangesAsync();
    }
}