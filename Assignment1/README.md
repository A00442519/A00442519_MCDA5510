# MCDA 5510 Assignment 1

## Objective:
Write a C# program to traverse a directory structure (DirWalker.cs) of csv files that contain csv files with customer info.

1. This program builds on the SimpleCSVParser and DirWalker already provided.
2. The program traverses through all the files in a directory, reads all rows in the CSV files and adds all rows to a new output file.
3. All the rows with missing info are skipped and logged in the log file using log4net. 
4. After the traversing, it logs execution time, number of valid rows and number of skipped rows in the logs. 
5. The program also uses the date from the directory structure into a new column field named "Date". 

## File Structure:
~~~~~~~
        Assignment1
          |-- Findings
                |-- ReadMe.pdf
          |-- Logs
                |-- logs.main
          |-- Output
                |-- output.csv             
          |-- Assignment1.csproj
		  |-- DirWalker.cs
		  |-- EmptyClass.cs
		  |-- Exceptions.cs
		  |-- SimpleCSVParser.cs
		  |-- bin/
				|-- 
		  |-- log.config
		  |-- obj/      
				|-- 
          |-- README
		  |-- Assignment1.sln
~~~~~~~

## Setup
To change data directory, change line no. 70 in DirWalker.cs with the appropriate path. 
