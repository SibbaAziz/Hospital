using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Hospital.Controls;
using Hospital.Models;
using Hospital.Repository;

namespace Hospital.Repository
{
    public class XmlRepository : IRepository
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
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Service>));

            // Declare an object variable of the type to be deserialized.
            List<Service> result;

            using (Stream reader = new FileStream("Data/services.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                result = (List<Service>)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
