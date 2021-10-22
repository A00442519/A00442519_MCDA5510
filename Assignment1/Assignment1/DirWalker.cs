using System;
using System.IO;

namespace Assignment1
{
  

    public class DirWalker
    {

        public void walk(String path)
        {
            SimpleCSVParser parser = new SimpleCSVParser();
            
            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                parser.parse(filepath);
                //Console.WriteLine("File:" + filepath);
            }
        }

        public static void Main(String[] args)
        {   
            DirWalker fw = new DirWalker();
            SimpleCSVParser parser = new SimpleCSVParser();

            //fw.walk(@"E:/MCDA/5510/MCDA5510_Assignments/Assignment1/Assignment1/testFiles/");
            fw.walk(@"E:/MCDA/5510/MCDA5510_Assignments/Sample Data"); 

        }

    }
}
