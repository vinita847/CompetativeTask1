using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using SeleniumExtras;



namespace MarsFramework.Global
{
    public class GlobalDefinitions
    {
        //Initialise the browser
        public static IWebDriver driver { get; set; }

        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }
        #endregion


        #region Excel 
        public static class ExcelLib
        {
            private static readonly List<Datacollection> DataCol = new List<Datacollection>();
            // The following code helps to quit the windows in which you only need to pass the name of excel.
            // ReSharper disable once UnusedMember.Local
            private static void QuitExcel(string processtitle)
            {
                var processes = from p in Process.GetProcessesByName("EXCEL")
                                select p;
                foreach (var process in processes)
                    if (process.MainWindowTitle == "Microsoft Excel - " + processtitle + " - Excel")
                        process.Kill();
            }
            private static void ClearData()
            {
                DataCol.Clear();
            }
            private static DataTable ExcelToDataTable(string fileName, string sheetName)
            {
                // Open file and return as Stream

                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))

                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });
                        //Get all the tables
                        var table = result.Tables;
                        // store it in data table
                        var resultTable = table[sheetName];
                        return resultTable;
                    }
                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations
                    rowNumber = rowNumber - 1;
                    var data = (from colData in DataCol
                                where (colData.ColName == columnName) && (colData.RowNumber == rowNumber)
                                select colData.ColValue).SingleOrDefault();
                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                    return data;
                }
                catch (Exception e)
                {
                    // ReSharper disable once LocalizableElement
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine +
                                      e.Message);
                    return null;
                }
            }
            public static void PopulateInCollection(string fileName, string sheetName)
            {
                ClearData();
                var table = ExcelToDataTable(fileName, sheetName);

                //Iterate through the rows and columns of the Table
                for (var row = 1; row <= table.Rows.Count; row++)
                    for (var col = 0; col < table.Columns.Count; col++)
                    {
                        var dtTable = new Datacollection
                        {
                            RowNumber = row,
                            ColName = table.Columns[col].ColumnName,
                            ColValue = table.Rows[row - 1][col].ToString()
                        };
                        //Add all the details for each row
                        DataCol.Add(dtTable);
                    }
            }
            private class Datacollection
            {
                public int RowNumber { get; set; }
                public string ColName { get; set; }
                public string ColValue { get; set; }
            }


        }

        #endregion


        //public static class ExcelLib
        //{
        //    static List<Datacollection> dataCol = new List<Datacollection>();

        //    public class Datacollection
        //    {
        //        public int rowNumber { get; set; }
        //        public string colName { get; set; }
        //        public string colValue { get; set; }
        //    }


        //    public static void ClearData()
        //    {
        //        dataCol.Clear();
        //    }


        //    private static DataTable ExcelToDataTable(string fileName, string SheetName)
        //    {
        //        // Open file and return as Stream
        //        using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
        //        {
        //            using (Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream))
        //            {
        //                excelReader.IsFirstRowAsColumnNames = true;

        //                //Return as dataset
        //                DataSet result = excelReader.AsDataSet();
        //                //Get all the tables
        //                DataTableCollection table = result.Tables;

        //                // store it in data table
        //                DataTable resultTable = table[SheetName];

        //                //excelReader.Dispose();
        //                //excelReader.Close();
        //                // return
        //                return resultTable;
        //            }
        //        }
        //    }

        //    public static string ReadData(int rowNumber, string columnName)
        //    {
        //        try
        //        {
        //            //Retriving Data using LINQ to reduce much of iterations

        //            rowNumber = rowNumber - 1;
        //            string data = (from colData in dataCol
        //                           where colData.colName == columnName && colData.rowNumber == rowNumber
        //                           select colData.colValue).SingleOrDefault();

        //            //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


        //            return data.ToString();
        //        }

        //        catch (Exception e)
        //        {
        //            //Added by Kumar
        //            Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
        //            return null;
        //        }
        //    }

        //    public static void PopulateInCollection(string fileName, string SheetName)
        //    {
        //        ExcelLib.ClearData();
        //        DataTable table = ExcelToDataTable(fileName, SheetName);

        //        //Iterate through the rows and columns of the Table
        //        for (int row = 1; row <= table.Rows.Count; row++)
        //        {
        //            for (int col = 0; col < table.Columns.Count; col++)
        //            {
        //                Datacollection dtTable = new Datacollection()
        //                {
        //                    rowNumber = row,
        //                    colName = table.Columns[col].ColumnName,
        //                    colValue = table.Rows[row - 1][col].ToString()
        //                };


        //                //Add all the details for each row
        //                dataCol.Add(dtTable);

        //            }
        //        }

        //    }
        //}





        #region screenshots
        public static class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (Base.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }
        #endregion
    }
}
