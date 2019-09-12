using System.Collections.Generic;
using System.Linq;
using Hospital.Core.Models;
using Hospital.Core.Repository;

namespace Hospital.Caching
{
    public static class CacheContext
    {
        private static IRepository _repository;
        private static IEnumerable<Service> _services;
        private static IEnumerable<string> _jobs;
        public static void SetRepository( IRepository repository)
        {
            _repository = repository;
        }

        public static IEnumerable<Service> GetServices()
        {
            return _services ?? (_services = _repository?.GetServices().ToList());
        }

        public static IEnumerable<string> GetJobs()
        {
            return _jobs ?? (_jobs = _repository?.GetJobs().ToList());
        }
    }
}
