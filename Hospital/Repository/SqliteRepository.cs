using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Hospital.Controls;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.Repository
{
    public class SqliteRepository : IRepository
    {
        public IList<Resource> GetResources()
        {
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Resource>));

            // Declare an object variable of the type to be deserialized.
            List<Resource> result;

            using (Stream reader = new FileStream("Data/data.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                result = (List<Resource>)serializer.Deserialize(reader);
            }

            return result;

        }

        public IList<Service> GetServices()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Services.ToList();
            }
        }
    }
}
