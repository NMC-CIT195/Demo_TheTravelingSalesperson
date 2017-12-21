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


        /// <summary>
        /// method to write all ski run info to the data file
        /// </summary>
        /// <param name="skiRuns">list of ski run info</param>
        /// <param name="dataFilePath">path to the data file</param>
        //public static void WriteAllSkiRuns(List<SkiRun> skiRuns, string dataFilePath)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<SkiRun>), new XmlRootAttribute("SkiRuns"));

        //    StreamWriter sWriter = new StreamWriter(dataFilePath);

        //    using (sWriter)
        //    {
        //        serializer.Serialize(sWriter, skiRuns);
        //    }            
        //}
    }
}

