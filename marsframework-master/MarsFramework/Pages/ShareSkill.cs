using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //click on share skill

        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        public IWebElement ShareSkillTab { get; set; }

        //add title
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        public IWebElement AddTitle { get; set; }

        //add description
        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement AddDescription { get; set; }

        //select category
        [FindsBy(How = How.Name, Using = "categoryId")]
        public IWebElement AddCategory { get; set; }

        //select subcategory
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        public IWebElement AddSubCategory { get; set; }




        //add tags
        [FindsBy(How = How.XPath, Using = "//h3[contains(text(), 'Tags')]//parent::div/following-sibling::div//input[@class='ReactTags__tagInputField']")]
        public IWebElement AddTags { get; set; }

        //click enter to add the tag
        Actions enterBtn = new Actions(Global.GlobalDefinitions.driver);

        //add service type: hourly basis
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='0']")]
        public IWebElement AddSeviceHourly { get; set; }

        //add service type: one off
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='1']")]
        public IWebElement AddServiceOneOff { get; set; }

        //add location type: Onsite
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='0']")]
        public IWebElement AddLocationOnsite { get; set; }

        //add location type: Online
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='1']")]
        public IWebElement AddLocationOnline { get; set; }


        //Identify Available date:start date
        [FindsBy(How = How.Name, Using = "startDate")]
        public IWebElement AvailableStartDate { get; set; }

        //Identify Available date:start date
        [FindsBy(How = How.Name, Using = "endDate")]
        public IWebElement AvailableEndDate { get; set; }

        //Identify Available days
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Sun')]//preceding-sibling::input")]
        public IWebElement AvailableDays { get; set; }

        //identify available Startime
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Sun')]//ancestor::div[2]//following-sibling::div//input[@name='StartTime']")]
        public IWebElement AvailableStartTime { get; set; }


        //identify available EndTime
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Sun')]//ancestor::div[2]//following-sibling::div//input[@name='EndTime']")]

        public IWebElement AvailableEndTime { get; set; }



        //seclect Skill trade: skill exchange
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='true']")]
        public IWebElement TradeSKillExchange { get; set; }

        //select Skill trade: credit
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='false']")]
        public IWebElement SelectCredit { get; set; }

        //skillExchange tags
        [FindsBy(How = How.XPath, Using = "//h3[contains(text(), 'Skill-Exchange')]//parent::div/following-sibling::div//input[@class='ReactTags__tagInputField']")]
        public IWebElement SKillExchangeTag { get; set; }

        //click enter to add the tag

        //add work sample
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding - 25']")]
        public IWebElement AddWorkSample { get; set; }

        //select active
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='true']")]
        public IWebElement SelectActive { get; set; }

        //selct hidden
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='false']")]
        public IWebElement SelectHidden { get; set; }

        //click on save
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement SaveSkill { get; set; }

        //click on cancel
        [FindsBy(How = How.XPath, Using = "//input[@value='Cancel']")]
        public IWebElement ClickCancel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")]
        public IWebElement SkillAddedSuccessMsg { get; set; }
        

        public ManageListings AddSkill()
        {

            //initialize excel sheet by calling the ExcelLib
            ExcelLib.PopulateInCollection(Base.ExcelPath, "AddShareSkill");

            ShareSkillTab.Click();
            AddTitle.SendKeys(ExcelLib.ReadData(2, "Title"));
            AddDescription.SendKeys(ExcelLib.ReadData(2, "Description"));
            AddCategory.SendKeys(ExcelLib.ReadData(2, "Category"));
            AddSubCategory.SendKeys(ExcelLib.ReadData(2, "Sub Category"));

            AddTags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            //will perform the enter button's functionality
            enterBtn.SendKeys(Keys.Return).Perform();
            AddServiceOneOff.Click();
            AddLocationOnline.Click();
            AvailableStartDate.SendKeys(ExcelLib.ReadData(2, "Start Date"));
            AvailableEndDate.SendKeys(ExcelLib.ReadData(2, "End Date"));

            AvailableDays.Click();
            AvailableStartTime.SendKeys(ExcelLib.ReadData(2, "Start Time"));
            AvailableEndTime.SendKeys(ExcelLib.ReadData(2, "End Time"));
            TradeSKillExchange.Click();
            SKillExchangeTag.SendKeys(ExcelLib.ReadData(2, "Skill Exchange Tage"));
            //will perform the enter button's functionality
            enterBtn.SendKeys(Keys.Return).Perform();
            //AddWorkSample.SendKeys("file path");
            SelectActive.Click();
            SaveSkill.Click();
            return new ManageListings();

        }


    }
}
