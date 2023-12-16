using CompetiviveTask_Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetiviveTask_Mars.Pages
{
    public class CertificationPage : CommonDriver
    {
        string popupMessage = "";
        string compare = "";

        int cancelFlag = 0;
        ProfilePage profile = new ProfilePage();

        public void AddCertification(string certificateName, string certifiedFrom, string year)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//div[contains(text(),'Add New')]"));
            addNewButton.Click();

            if (!string.IsNullOrEmpty(certificateName))
            {
                IWebElement addCertificateTextBox = driver.FindElement(By.Name("certificationName"));
                addCertificateTextBox.Click();
                addCertificateTextBox.SendKeys(certificateName);
            }
           
            if (!string.IsNullOrEmpty(certifiedFrom))
            {
                IWebElement addCertifiedFromTextBox = driver.FindElement(By.Name("certificationFrom"));
                addCertifiedFromTextBox.Click();
                addCertifiedFromTextBox.SendKeys(certifiedFrom);
            }
            if (!string.IsNullOrEmpty(year))
            {
                IWebElement chooseYearDD = driver.FindElement(By.Name("certificationYear"));
                chooseYearDD.Click();
                chooseYearDD.SendKeys(year);
                chooseYearDD.Click();
            }
            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                IWebElement addButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[1][@value='Add']"));
                addButton.Click();
            }
        }
        public void DeleteAllCertificationRecords()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='fourth']//tbody")).Count;

            for (int i = 1; i <= rowcount;)
            {

                IWebElement CertificateNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[1]//td[1]"));
                string CertificateName = CertificateNameTextBox.Text;

                IWebElement DeleteButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[1]//i[@class='remove icon']"));
                DeleteButton.Click();

                rowcount--;

                Thread.Sleep(1000);
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                popupMessage = messageBox.Text;

                compare = CertificateName + " has been deleted from your certification";

                Console.WriteLine(popupMessage);
                Assert.That(popupMessage.Equals(compare), "The education record has not been deleted successfully");

                Thread.Sleep(2000);

            }
        }
        public void AddNewCertification(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName +" has been added to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been added successfully");

        }

    }
}
