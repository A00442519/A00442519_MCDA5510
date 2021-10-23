using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class SimpleCSVParser
    {


        //public static void Main(String[] args)
        //{
        //    SimpleCSVParser parser = new SimpleCSVParser();
        //    parser.parse(@"sampleFile.csv");
        //}


        public string parse(String fileName,ref int skippedRows, ref int validRows)
        {
            //int skippedRows = 0;
            //int validRows = 0;
            string fileText = String.Empty;
            try { 
            using (TextFieldParser parser = new TextFieldParser(fileName))
            {
                    string[] listFileName = fileName.Split("\\");
                    string date = listFileName[listFileName.Length- 4] + '/' + 
                        listFileName[listFileName.Length - 3] + '/' + 
                        listFileName[listFileName.Length - 2] ;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                {
                        //Process row
                        string row = "";                
                        string[] fields = parser.ReadFields();
                        int rowInvalid = 0;
                        foreach (string field in fields)
                        {   
                            row = row + field + ",";
                            if (String.IsNullOrEmpty(field))
                            {
                                rowInvalid = 1;
                                break;
                            }
                            
                        }
                        if (rowInvalid==0)
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
        }catch(IOException ioe){
                Console.WriteLine(ioe.StackTrace);
         }

            return fileText;

    }


    }
}
