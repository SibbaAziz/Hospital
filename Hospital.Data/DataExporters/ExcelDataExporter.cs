using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Hospital.Core.Exporters;
using Hospital.Core.Models;
using OfficeOpenXml;

namespace Hospital.Data.DataExporters
{
    public class ExcelDataExporter : IDataExporter
    {
        public void Export(IEnumerable<PlanningUnit> planningUnit)
        {
            var data = planningUnit.SelectMany(p => p.Employees.Select(e => new
            {
                Date = p.Date,
                Nom = e.Employee.Name,
                Poste = e.Employee.Job,
                Absence = e.IsAbsent,
                Email = e.Employee.Email,
                Mobile = e.Employee.PhoneNumber
            })).ToArray();

            using (var excel = new ExcelPackage(new FileInfo(@"c:\workbooks\myworkbook.xlsx")))
            {
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(data, true).AutoFitColumns();
                excel.Save();
            }
        }
    }
}
