using MarsFramework.Pages;
using NUnit.Framework;
using System.Collections.Generic;
using MarsFramework.Global;
using System;
using System.Threading;
using OpenQA.Selenium;

namespace MarsFramework
{
    class Program 
    {
        [TestFixture]
        [Category("Sprint1")]
        public class User : Base

        {
            public object ExcelLib { get; private set; }

            [Test]
            public void AddSkill()
            
            {
                ShareSkill AddShareSkill = new ShareSkill();
                AddShareSkill.AddSkill();
                //Thread.Sleep(2000);
                try
                {
                    string ExpectedMsg = "Service Listing Added successfully";
                    GlobalDefinitions.wait(10);
                    //GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div"), 10);
                    string ActulaMsg = AddShareSkill.SkillAddedSuccessMsg.Text;
                    GlobalDefinitions.wait(10);

                    Assert.AreEqual(ExpectedMsg, ActulaMsg);
                    Console.WriteLine(ExpectedMsg);

                }
                catch (NoSuchElementException)
                {
                    Console.Write("Skill Add element not found");
                }

                
            }

            [Test]
            public void UpdateSkill()
            {
                ManageListings SkillEdit = new ManageListings();
                SkillEdit.EditExistingSkill();

                try
                {
                    string ExpectedUpdateMsg = "Service Listing Updated successfully";
                    //GlobalDefinitions.wait(10);

                    //GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div"), 10);

                    string ActualMsg = SkillEdit.SuccessMsg.Text;
                    //GlobalDefinitions.wait(10);

                    Assert.AreEqual(ExpectedUpdateMsg, ActualMsg);
                    Console.WriteLine(ExpectedUpdateMsg);

                }
                catch (NoSuchElementException)
                {
                    Console.Write("Skill Update element not found");
                }
            }


                [Test]

            public void DeleteSkill()
            {
                ManageListings SkillDelete = new ManageListings();
                SkillDelete.DeleteExistingSkill();
                //Thread.Sleep(2000);
                string ExpectedUpdateMsg = "Selenium has been deleted";
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string ActualMsg = SkillDelete.SuccessMsg.Text;

                Assert.AreEqual(ExpectedUpdateMsg, ActualMsg);
                Console.WriteLine(ExpectedUpdateMsg);
            }

        }



        
    }
}