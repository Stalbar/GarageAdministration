using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.DTOs;

namespace GarageAdministration.EF.Commands;

public class CreateReportCommand: ICreateCommand<Report>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreateReportCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Report entity)
    {
        await using var context = _contextFactory.Create();
        var reportDto = new ReportDto()
        {
            CreationDate = entity.CreationDate,
            PathToFile = entity.PathToFile,
        };
        context.Reports.Add(reportDto);
        await context.SaveChangesAsync();
    }
}