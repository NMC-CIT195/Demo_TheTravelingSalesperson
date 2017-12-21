using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo_TheTravelingSalesperson
{
    public class XmlServices
    {
        public Salesperson ReadSalespersonData(string dataFilePath)
        {
            Salesperson salesperson = new Salesperson();

            // initialize a FileStream object for reading
            StreamReader sReader = new StreamReader(DataSettings.dataFilePathXml);

            // initialize an XML seriailizer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Salesperson));

            using (sReader)
            {
                object xmlObject = deserializer.Deserialize(sReader);
                Console.WriteLine(xmlObject);
                salesperson = (Salesperson)xmlObject;
            }

            return salesperson;
        }
    }
}
