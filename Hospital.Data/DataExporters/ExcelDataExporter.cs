using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Date = p.Date.ToString("dd/MM/yyyy"),
                Nom = e.Employee.Name,
                Poste = e.Employee.Job,
                Absence = e.IsAbsent,
                Email = e.Employee.Email,
                Periode = p.DayNight == Core.Helpers.DayNight.Day ? "Jour" : "Nuit",
                Mobile = e.Employee.PhoneNumber
            })).ToArray();

            var directory = @"c:\workbooks";
            var filename = $"planning_{DateTime.Now.ToString("ddMMyyyyhhmm")}.xlsx";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var fullfilename = Path.Combine(directory, filename);

            using (var excel = new ExcelPackage(new FileInfo(fullfilename)))
            {
                var workSheet = excel.Workbook.Worksheets.Add("Planning");
                workSheet.Cells.LoadFromCollection(data, true).AutoFitColumns();
                excel.Save();
            }

            Process.Start(fullfilename);
        }
    }
}
