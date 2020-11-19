using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

using System;

namespace MarsFramework.Pages
{
    class SignIn: GlobalDefinitions
    {
        public SignIn()
        {
            //PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            PageFactory.InitElements(driver, this);

        }



        #region  Initialize Web Elements 
        //identify SignIn button
        //adding attribute
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        public IWebElement SignInBtn { get; set; } //is aproperty

        //identify email field
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement EenterEmail { get; set; }

        //identify password field
        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement EnterPwd { get; set; }

        //identify login button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[4]/button")]
        public IWebElement LogInBtn { get; set; }

        //identify valid user name
        [FindsBy(How = How.XPath, Using = "//span[@class='item ui dropdown link']/text()[2]")]
        public IWebElement ValidUserName { get; set; }

        #endregion

        //write a method for this page operation here and call it in the programe
        public Profile LoginSteps()
        {

            //initialize excel sheet by calling the ExcelLib
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignInPage");


            SignInBtn.Click();
            //wait
            wait(5);
            EenterEmail.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));
            EnterPwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            LogInBtn.Click();
           //return the ProfilePageObject
            return new Profile();
            
                       

        }

    }
}