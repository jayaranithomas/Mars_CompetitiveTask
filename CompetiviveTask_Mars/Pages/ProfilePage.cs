using CompetiviveTask_Mars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetiviveTask_Mars.Pages
{
    public class ProfilePage : CommonDriver
    {
        public void SelectEducationTab()
        {

            Wait.WaitToBeVisible("XPath", "//a[@data-tab='third']", 2);

            IWebElement educationTab = driver.FindElement(By.XPath("//a[@data-tab='third']"));
            educationTab.Click();

        }

        public void SelectCertificationsTab()
        {

            Wait.WaitToBeVisible("XPath", "//a[@data-tab='fourth']", 3);
            Thread.Sleep(4000);

            IWebElement certificationsTab = driver.FindElement(By.XPath("//a[@data-tab='fourth']"));
            certificationsTab.Click();

        }
    }
}
