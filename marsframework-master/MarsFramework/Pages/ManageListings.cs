using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;





namespace MarsFramework.Pages
{
    class ManageListings:GlobalDefinitions
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        //click on Manage listing tab
        //Manage Listing tab

        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        public IWebElement ManageListinTab { get; set; }

        //click on edit icon of 'Selenium'

        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[2]")]
        public IWebElement EditSkillIcon { get; set; }

        //find delete icon
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[3]")]
        public IWebElement DeleteSkillIcon { get; set; }

        //Yes for delete confirmation
        [FindsBy(How = How.XPath, Using = "//body/div[2]/div[1]/div[3]/button[2]")]
        public IWebElement YesToDelete { get; set; }

        //No for delete skill
        [FindsBy(How = How.XPath, Using = "//body/div[2]/div[1]/div[3]/button[1]")]
        public IWebElement NoToDelete { get; set; }


        //locate the title


        //edit title
        [FindsBy(How = How.Name, Using = "title")]
        public IWebElement UpdateTitle { get; set; }

        //Edit description
        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement AddDescription { get; set; }

        //Edit tags (add new tag)
        [FindsBy(How = How.XPath, Using = "//h3[contains(text(), 'Tags')]//parent::div/following-sibling::div//input[@class='ReactTags__tagInputField']")]
        public IWebElement AddTags { get; set; }

        //click enter to add the tag
        Actions enterBtn = new Actions(Global.GlobalDefinitions.driver);

        //Edit Available days
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Sat')]//preceding-sibling::input")]
        public IWebElement AvailableDays { get; set; }

        //Add available Startime
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Sat')]//ancestor::div[2]//following-sibling::div//input[@name='StartTime']")]
        public IWebElement AvailableStartTime { get; set; }


        //Add available EndTime
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Sat')]//ancestor::div[2]//following-sibling::div//input[@name='EndTime']")]

        public IWebElement AvailableEndTime { get; set; }

        //click on save
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement SaveSkill { get; set; }

        //confirmation message to for Update and Delete skill
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")]
        public IWebElement SuccessMsg { get; set; }



        public ManageListings EditExistingSkill()
        {
            //initialize excel sheet by calling the ExcelLib

            ExcelLib.PopulateInCollection(Base.ExcelPath, "EditSkill");

            ManageListinTab.Click();
            EditSkillIcon.Click();
            //Thread.Sleep(2000);
            UpdateTitle.Clear();
            UpdateTitle.SendKeys(ExcelLib.ReadData(2, "Title"));
            AddDescription.Clear();
            AddDescription.SendKeys(ExcelLib.ReadData(2, "Description"));
            AddTags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            enterBtn.SendKeys(Keys.Return).Perform();
            AvailableDays.Click();
            AvailableStartTime.SendKeys(ExcelLib.ReadData(2, "Start Time"));
            AvailableEndTime.SendKeys(ExcelLib.ReadData(2, "End Time"));
            SaveSkill.Click();
            return new ManageListings();



        }

        public void DeleteExistingSkill()
        {
            ManageListinTab.Click();
            DeleteSkillIcon.Click();
            //switch to alert popup
            //driver.SwitchTo().Alert();
            YesToDelete.Click();


        }
    }
}
