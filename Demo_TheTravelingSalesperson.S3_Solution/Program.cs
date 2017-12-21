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
            InitializeDataFileCsv dataInitializer = new InitializeDataFileCsv();
            dataInitializer.SeedDataFile();

            Controller appController = new Controller();
        }
    }
}
