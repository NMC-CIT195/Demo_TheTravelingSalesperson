using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo_TheTravelingSalesperson
{
    public class InitializeDataFileXml
    {
        public void SeedDataFile()
        {
            XmlServices xmlService = new XmlServices(DataSettings.dataFilePathXml);

            xmlService.WriteSalespersonToDataFile(InitializeSalesperson());
        }

        private Salesperson InitializeSalesperson()
        {
            Salesperson salesperson = new Salesperson()
            {
                FirstName = "Bonzo",
                LastName = "Regan",
                AccountID = "banana103",
                CurrentStock = new Product(Product.WidgetType.Furry, 20, false),
                CitiesVisited = new List<string>()
                {
                    "Detroit",
                    "Grand Rapids",
                    "Ann Arbor"
                }
            };

            return salesperson;
        }

        //public static void WriteSalespersonToFile(Salesperson salesperson)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(Salesperson), new XmlRootAttribute("Salesperson"));

        //    StreamWriter sWriter = new StreamWriter(DataSettings.dataFilePathXml);

        //    using (sWriter)
        //    {
        //        serializer.Serialize(sWriter, salesperson);
        //    }
        //}
    }
}

