using GarageAdministration.Infrastracture.Enums;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace GarageAdministration.WPF.Services.Implementations.Reports;

public class GarageReport: IReport
{
    private readonly GaragesStore _garagesStore;

    public GarageReport(GaragesStore garagesStore)
    {
        _garagesStore = garagesStore;
    }
    public IEnumerable<byte> Generate()
    {
        var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Отчет по гаражам");
        
        FillHeader(sheet);

        FillData(sheet);  
        
        StyleReport(sheet);
        
        return package.GetAsByteArray();
    }

    private void FillHeader(ExcelWorksheet sheet)
    {
        sheet.Cells["A1"].Value = "Идентификатор гаража";
        sheet.Cells["B1"].Value = "Адрес";
        sheet.Cells["C1"].Value = "Фамилия владельца";
        sheet.Cells["D1"].Value = "Имя владельца";
        sheet.Cells["E1"].Value = "Отчество владельца";
        sheet.Cells["F1"].Value = "Сумма взноса за электричество";
        sheet.Cells["G1"].Value = "Статус оплаты взноса за электричество";
        sheet.Cells["H1"].Value = "Сумма членского взноса";
        sheet.Cells["I1"].Value = "Статус оплаты членского взноса";
    }

    private void FillData(ExcelWorksheet sheet)
    {
        var row = 2;
        var column = 1;
        foreach (var garage in _garagesStore.Garages)
        {
            sheet.Cells[row, column].Value = garage.Id;
            sheet.Cells[row, column + 1].Value = garage.Map!.Name;
            sheet.Cells[row, column + 2].Value = garage.Owner.Surname;
            sheet.Cells[row, column + 3].Value = garage.Owner.Name;
            sheet.Cells[row, column + 4].Value = garage.Owner.Patronymic;
            sheet.Cells[row, column + 5].Value = garage.Contribution.ElectricityFee;
            sheet.Cells[row, column + 6].Value = garage.Contribution.ElectricityFeePaymentStatus == PaymentStatus.Paid
                ? "Оплачено"
                : "Не оплачено";
            sheet.Cells[row, column + 7].Value = garage.Contribution.MembershipFee;
            sheet.Cells[row, column + 8].Value = garage.Contribution.MembershipFeePaymentStatus == PaymentStatus.Paid
                ? "Оплачено"
                : "не оплачено";
            row++;
        }
    }

    private void StyleReport(ExcelWorksheet sheet)
    {
        var length = _garagesStore.Garages.Count();
        sheet.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
        sheet.Column(8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
        sheet.Cells["A1:I1"].Style.Font.Bold = true;
        sheet.Cells[1, 1, length + 1, 9].AutoFitColumns();
        for (var i = 1; i <= length + 1; i++)
        {
            for (var j = 1; j <= 9; j++)
            {
                sheet.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }
        }
    }

    public override string ToString() => "Отчет по гаражам";
}