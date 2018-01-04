using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // seed data file
            //
            InitializeDataFileCsv dataInitializerCsv = new InitializeDataFileCsv();
            dataInitializerCsv.SeedDataFile();
            InitializeDataFileXml dataInitializerXml = new InitializeDataFileXml();
            dataInitializerXml.SeedDataFile();

            //
            // debug write and read seed data
            //
            //XmlServices IoServicesXml = new XmlServices(DataSettings.dataFilePathXml);
            //Salesperson salespersonXml = IoServicesXml.ReadSalespersonFromDataFile();
            //CsvServices IoServicesCsv = new CsvServices(DataSettings.dataFilePathCsv);
            //Salesperson salepersonCsv = IoServicesCsv.ReadSalespersonFromDataFile();

            Controller appController = new Controller();
        }
    }
}
