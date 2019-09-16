using Hospital.Core.Models;
using System.Collections.Generic;

namespace Hospital.Core.Exporters
{
    public interface IDataExporter
    {
        void Export(IEnumerable<PlanningUnit> planningUnit);
    }
}
