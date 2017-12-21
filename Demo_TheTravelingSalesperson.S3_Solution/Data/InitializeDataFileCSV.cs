using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    public class InitializeDataFileCsv
    {
        public void SeedDataFile()
        {
            WriteSalespersonToFile(InitializeSalesperson());
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


        public static void WriteSalespersonToFile(Salesperson salesperson)
        {
            string salespersonData;
            char delineator = ',';

            StringBuilder sb = new StringBuilder();

            //
            // add salesperson and product info to string
            //
            sb.Clear();
            sb.Append(salesperson.FirstName + delineator);
            sb.Append(salesperson.LastName + delineator);
            sb.Append(salesperson.AccountID + delineator);
            sb.Append(salesperson.CurrentStock.Type.ToString() + delineator);
            sb.Append(salesperson.CurrentStock.NumberOfUnits.ToString() + delineator);
            sb.Append(salesperson.CurrentStock.OnBackorder.ToString());
            sb.Append(Environment.NewLine);

            //
            // add cities traveled to the string
            //
            foreach (string city in salesperson.CitiesVisited)
            {
                sb.Append(city + delineator);
            }

            //
            // convert StringBuilder object to a string
            //
            salespersonData = sb.ToString();

            // initialize a FileStream object for writing
            FileStream wfileStream = File.OpenWrite(DataSettings.dataFilePathCsv);

            // wrap the FieldStream object in a using statement to ensure of the dispose
            using (wfileStream)
            {
                // wrap the FileStream object in a StreamWriter object to simplify writing strings
                StreamWriter sWriter = new StreamWriter(wfileStream);

                using (sWriter)
                {
                    sWriter.Write(salespersonData);
                }
            }
        }
    }
}
