using GarageAdministration.Infrastracture.Enums;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace GarageAdministration.WPF.Services.Implementations.Reports;

public class OwnersReport: IReport
{
    private readonly OwnersStore _ownersStore;

    public OwnersReport(OwnersStore ownersStore)
    {
        _ownersStore = ownersStore;
    }

    public IEnumerable<byte> Generate()
    {
        var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Отчет по владельцам");

        FillHeader(sheet);

        FillData(sheet);

        StyleReport(sheet);

        return package.GetAsByteArray();
    }

    private void FillHeader(ExcelWorksheet sheet)
    {
        sheet.Cells["A1"].Value = "Идентификатор владельца";
        sheet.Cells["B1"].Value = "Фамилия владельца";
        sheet.Cells["C1"].Value = "Имя владельца";
        sheet.Cells["D1"].Value = "Отчетство владельца";
        sheet.Cells["E1"].Value = "Количество гаражей";
        sheet.Cells["F1"].Value = "Адрес гаражного кооператива";
        sheet.Cells["G1"].Value = "Статус оплаты взноса за электричество";
        sheet.Cells["H1"].Value = "Общая сумма взноса за электричество";
        sheet.Cells["I1"].Value = "Статус оплаты членского взноса";
        sheet.Cells["J1"].Value = "Общая сумма членского взноса";
    }

    private void FillData(ExcelWorksheet sheet)
    {
        var row = 2;
        var column = 1;
        foreach (var owner in _ownersStore.Owners)
        {
            sheet.Cells[row, column].Value = owner.Id;
            sheet.Cells[row, column + 1].Value = owner.Surname;
            sheet.Cells[row, column + 2].Value = owner.Name;
            sheet.Cells[row, column + 3].Value = owner.Patronymic;
            sheet.Cells[row, column + 4].Value = owner.Garages.Count;
            sheet.Cells[row, column + 5].Value = owner.Garages.Any() ? owner.Garages.First().Map!.Name : "";
            sheet.Cells[row, column + 6].Value =
                owner.Garages.Any(g => g.Contribution.ElectricityFeePaymentStatus == PaymentStatus.NotPaid)
                    ? "Не оплачено"
                    : "Оплачено";
            sheet.Cells[row, column + 7].Value = owner.Garages.Sum(g => g.Contribution.ElectricityFee);
            sheet.Cells[row, column + 8].Value =
                owner.Garages.Any(g => g.Contribution.MembershipFeePaymentStatus == PaymentStatus.NotPaid)
                    ? "Не оплачено"
                    : "Оплачен";
            sheet.Cells[row, column + 9].Value = owner.Garages.Sum(g => g.Contribution.MembershipFee);
            row++;
        }
    }

    private void StyleReport(ExcelWorksheet sheet)
    {
        var length = _ownersStore.Owners.Count();
        sheet.Cells["A1:J1"].Style.Font.Bold = true;
        sheet.Cells[1, 1, length + 1, 10].AutoFitColumns();
        for (var i = 1; i <= length + 1; i++)
        {
            for (var j = 1; j <= 10; j++)
            {
                sheet.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }
        }
    }

    public override string ToString() => "Отчет по владельцам";
}