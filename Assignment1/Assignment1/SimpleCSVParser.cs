using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{

    public class SimpleCSVParser
    {

        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);



        //public static void Main(String[] args)
        //{
        //    SimpleCSVParser parser = new SimpleCSVParser();
        //    parser.parse(@"sampleFile.csv");
        //}


        public string parse(String fileName, ref int skippedRows, ref int validRows)
        {

            var logRepo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepo, new FileInfo("log.config"));

            string fileText = String.Empty;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    string[] listFileName = fileName.Split("\\");
                    string date = listFileName[listFileName.Length - 4] + '/' +
                        listFileName[listFileName.Length - 3] + '/' +
                        listFileName[listFileName.Length - 2];
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        //Process row
                        string row = "";
                        string[] fields = parser.ReadFields();
                        if (fields[0] == "First Name")
                        {
                            continue;
                        }
                        int rowInvalid = 0;
                        foreach (string field in fields)
                        {

                            row = row + field + ",";
                            if (String.IsNullOrEmpty(field))
                            {
                                rowInvalid = 1;
                                log.Info("Row Skipped in "+ fileName);
                                break;
                            }
                        }
                        if (rowInvalid == 0)
                        {
                            //File.AppendAllText("E:/MCDA/5510/MCDA5510_Assignments/Assignment1/Assignment1/testOp.csv", row + "\n");
                            fileText = fileText + row + date + "\n";
                            validRows++;
                        }
                        else
                        {
                            skippedRows++;
                        }
                    }
                }
            }
            catch (IOException ioe)
            {
                log.Error(ioe.StackTrace);
            }

            return fileText;

        }


    }
}
