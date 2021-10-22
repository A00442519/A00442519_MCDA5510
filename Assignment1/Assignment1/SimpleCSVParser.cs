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


        public void parse(String fileName)
        {
            int skippedRows = 1; 
            try { 
            using (TextFieldParser parser = new TextFieldParser(fileName))
            {
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
                            File.AppendAllText("E:/MCDA/5510/MCDA5510_Assignments/Assignment1/Assignment1/testOp.csv", row + "\n");
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

    }


    }
}
