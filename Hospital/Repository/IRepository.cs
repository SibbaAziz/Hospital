using System.Collections.Generic;
using Hospital.Controls;
using Hospital.Models;

namespace Hospital.Repository
{
    public interface IRepository
    {
        IList<Resource> GetResources();
        IList<Service> GetServices();
    }
}
