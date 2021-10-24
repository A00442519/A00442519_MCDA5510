using log4net;
using log4net.Config;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Assignment1
{
  

    public class DirWalker
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public void walk(String path, ref int skippedRows, ref int validRows, ref string outputPath)
        {

            //string outputPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "/Output/";
            SimpleCSVParser parser = new SimpleCSVParser();
            
            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath, ref skippedRows, ref validRows, ref outputPath);
                    // Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                string fileText = parser.parse(filepath, ref skippedRows, ref validRows);
                File.AppendAllText(outputPath + "/Output.csv", fileText);
            }
            
        }

        public static void Main(String[] args)
        {
            var logRepo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepo, new FileInfo("log.config"));

            //log.Info(sMessage);

            //log.Error(sMessage);

            var timer = new Stopwatch();
            timer.Start();
            int skippedRows = 0;
            int validRows = 0;

            DirWalker fw = new DirWalker();
            SimpleCSVParser parser = new SimpleCSVParser();

            string outputPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "/Output/";

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            File.AppendAllText(outputPath + "/Output.csv", "First Name,Last Name,Street Number,Street,City," +
                "Province,Postal Code,Country,Phone Number,email Address,Date\n");
            fw.walk(@"E:\MCDA\5510\MCDA5510_Assignments\Sample Data", ref skippedRows, ref validRows, ref outputPath);

            timer.Stop();

            File.AppendAllText(outputPath + "/Output.csv", 
                "Execution Time:" +  timer.Elapsed.Seconds + "seconds\nSkipped Rows: " + skippedRows + "\nValid Rows: " + validRows);
     

        }

    }
}
