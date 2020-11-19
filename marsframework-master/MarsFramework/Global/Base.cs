using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
using static MarsFramework.Global.GlobalDefinitions;




namespace MarsFramework.Global
{
    public class Base
    {
        #region To access Path from resource file

       
        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;


        //public static string ExcelPath = @"V:\marsframework-master\marsframework-master\MarsFramework\Test Data\LogInData.xlsx";
        //public static string ScreenshotPath = @"V:\marsframework-master\Screen_Shots";
        //public static string ReportPath = "V:/marsframework-master/marsframework-master/MarsFramework/Test Rports";
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
           

            //advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    break;
                    

            }
            //nevigate to home page
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);

            #endregion


            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();

                try
                {
                    string ExpectedUserName = "vinita";
                    //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    string ActualUserName = loginobj.ValidUserName.Text;
                    Assert.AreEqual(ExpectedUserName, ActualUserName);
                    Console.WriteLine(ExpectedUserName);

                }
                catch (NoSuchElementException)
                {
                    Console.Write("User Name not found");
                }


                
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(driver, "Report"); // "V:/marsframework-master/marsframework-master/MarsFramework/Reports");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test.Log(LogStatus.Info,
                "Image example: " + img);
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)            
            driver.Close();
            driver.Quit();
        }
        #endregion

    }
}