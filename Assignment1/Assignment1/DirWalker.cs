using System;
using System.Diagnostics;
using System.IO;

namespace Assignment1
{
  

    public class DirWalker
    {

        public void walk(String path, ref int skippedRows, ref int validRows)
        {
            

            SimpleCSVParser parser = new SimpleCSVParser();
            
            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath, ref skippedRows, ref validRows);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                string fileText = parser.parse(filepath, ref skippedRows, ref validRows);
                File.AppendAllText("E:/MCDA/5510/MCDA5510_Assignments/Assignment1/Assignment1/testOp.csv", fileText);
                //Console.WriteLine("File:" + filepath);
            }
            
        }

        public static void Main(String[] args)
        {
            var timer = new Stopwatch();
            timer.Start();
            int skippedRows = 0;
            int validRows = 0;

            DirWalker fw = new DirWalker();
            SimpleCSVParser parser = new SimpleCSVParser();

            //fw.walk(@"E:/MCDA/5510/MCDA5510_Assignments/Assignment1/Assignment1/testFiles/");
            fw.walk(@"E:\MCDA\5510\MCDA5510_Assignments\Sample Data", ref skippedRows, ref validRows);

            timer.Stop();
            File.AppendAllText("E:/MCDA/5510/MCDA5510_Assignments/Assignment1/Assignment1/testOp.csv", 
                "Execution Time:" +  timer.Elapsed.Seconds);
            File.AppendAllText("E:/MCDA/5510/MCDA5510_Assignments/Assignment1/Assignment1/testOp.csv", 
                "\nSkipped Rows: " + skippedRows);
            File.AppendAllText("E:/MCDA/5510/MCDA5510_Assignments/Assignment1/Assignment1/testOp.csv", 
                "\nValid Rows: " + validRows);

        }

    }
}
