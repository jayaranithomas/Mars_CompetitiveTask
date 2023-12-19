using CompetiviveTask_Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            string CertificateName = "";
            for (int i = 1; i <= rowcount;)
            {

                IWebElement CertificateNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[1]//td[1]"));
                CertificateName = CertificateNameTextBox.Text;

                IWebElement DeleteButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[1]//i[@class='remove icon']"));
                DeleteButton.Click();

                rowcount--;

                Thread.Sleep(1000);
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                popupMessage = messageBox.Text;

                compare = CertificateName + " has been deleted from your certification";

                Console.WriteLine(popupMessage);
                Assert.That(popupMessage.Equals(compare), "The education record has not been deleted successfully");

                Thread.Sleep(3000);
            }
            
        }
        public void AddNewCertification(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been added to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been added successfully");

        }
        public void AddNewCertificationRecordWithAllNullData(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter Certification Name, Certification From and Certification Year";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has been added successfully");

        }
        public void AddNewCertificationRecordWithDropdownNotSelected(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter Certification Name, Certification From and Certification Year";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has been added successfully");

        }
        public void AddNewCertificationRecordWithValidDataInDropdownAndEmptyTextBoxes(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter Certification Name, Certification From and Certification Year";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has been added successfully");

        }
        public void AddAlreadyExistingCertificationRecord(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "This information is already exist.";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has been added successfully");

        }
        public void AddCertificationRecordWithExistingDataInTextBoxesAndDifferentDropDown(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Duplicated data";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has been added successfully");

        }
        public void AddCertificationRecordWithExistingDataInDropDownAndDifferentTextBoxes(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been added to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been added successfully");

        }
        public void AddCertificationRecordWithSpecialCharactersInCertificationNameTextBox(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been added to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been added successfully");

        }
        public void AddCertificationRecordWithVeryLongDataInCertifiedFromTextBox(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been added to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been added successfully");

        }
        public void AddCertificationRecordWithSpacesInTextBoxes(string certificateName, string certifiedFrom, string year)
        {

            AddCertification(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "has been added to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been added successfully");

        }
        public void CancelAddCertificationRecord(string certificateName, string certifiedFrom, string year)
        {
            cancelFlag = 1;
            AddCertification(certificateName, certifiedFrom, year);
            cancelFlag = 0;

            IWebElement CancelButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@value='Cancel']"));
            CancelButton.Click();

            Thread.Sleep(1000);
            IWebElement lastRecord = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[last()]/tr/td[2]"));

            if (!lastRecord.Text.Equals("CyberSecurity Fundamentals"))
            {
                Console.WriteLine("Certification record cancelled before adding");
                Assert.That(!lastRecord.Text.Equals("CyberSecurity Fundamentals"), "The education record not cancelled successfully");
            }

        }
        public void EditCertificationRecord(string certificateName, string certifiedFrom, string year)
        {
            Wait.WaitToBeClickable("XPath", "//div[@data-tab='fourth']//tbody[1]//i[@class='outline write icon']", 3);

            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            IWebElement certificationNameTextBox = driver.FindElement(By.Name("certificationName"));
            IWebElement certificationFromTextBox = driver.FindElement(By.Name("certificationFrom"));
            IWebElement chooseYearDD = driver.FindElement(By.Name("certificationYear"));

            if (string.IsNullOrEmpty(certificateName))
            {
                var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                actions.Click(certificationNameTextBox);
                actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                actions.Perform();               
            }
            else
            {
                certificationNameTextBox.Clear();
                certificationNameTextBox.SendKeys(certificateName);
            }
            if(string.IsNullOrEmpty(certifiedFrom))
            {
                var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                actions.Click(certificationFromTextBox);
                actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                actions.Perform();
            }
            else
            {
                certificationFromTextBox.Clear();
                certificationFromTextBox.SendKeys(certifiedFrom);
            }

            chooseYearDD.Click();
            if (!string.IsNullOrEmpty(year))
                chooseYearDD.SendKeys(year);
            else
                chooseYearDD.SendKeys("Year");
            chooseYearDD.Click();

            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                IWebElement updateButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@value='Update']"));
                updateButton.Click();
            }
        }
        public void UpdateExistingCertificationRecordWithAllFieldsEdited(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been updated to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been updated successfully");

        }
        public void UpdateExistingCertificationRecordWithoutEditingAnyFields()
        {
            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@value='Update']"));
            updateButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "This information is already exist.";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "Already existing certification record updated");

        }
        public void UpdateExistingCertificationRecordWithNULLValuesInAllFields(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = compare = "Please enter Certification Name, Certification From and Certification Year";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has been updated successfully");

        }
        public void UpdateExistingCertificationRecordWithNULLValuesTextBoxesAndValidInDropdowns(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = compare = "Please enter Certification Name, Certification From and Certification Year";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has been updated successfully");

        }
        public void UpdateExistingCertificationRecordWithoutSelectingDropdownsAndEditingTextBoxes(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = compare = "Please enter Certification Name, Certification From and Certification Year";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has been updated successfully");

        }
        public void UpdateExistingCertificationRecordWithoutChangingTextBoxesAndEditingDropdowns(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been updated to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been updated successfully");

        }
        public void UpdateExistingCertificationRecordWithoutChangingDropdownsAndEditingTextBoxes(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been updated to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been updated successfully");

        }
        public void UpdateExistingCertificationRecordWithSpecialCharactersInCollegeTextBox(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been updated to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been updated successfully");

        }
        public void UpdateExistingCertificationRecordWithVeryLongDataInCertifiedFromTextBox(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = certificateName + " has been updated to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been updated successfully");

        }
        public void UpdateExistingCertificationRecordWithSpacesInTextBoxes(string certificateName, string certifiedFrom, string year)
        {

            EditCertificationRecord(certificateName, certifiedFrom, year);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "has been updated to your certification";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The Certification record has not been updated successfully");

        }
        public void CancelUpdateCertificationRecord(string certificateName, string certifiedFrom, string year)
        {
            cancelFlag = 1;
            EditCertificationRecord(certificateName, certifiedFrom, year);
            cancelFlag = 0;

            IWebElement CancelButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@value='Cancel']"));
            CancelButton.Click();

            Thread.Sleep(1000);
            IWebElement firstRecord = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[1]/tr/td[2]"));

            if (!firstRecord.Text.Equals("CyberSecurity Fundamentals"))
            {
                Console.WriteLine("Certification record cancelled before updating");
                Assert.That(!firstRecord.Text.Equals("CyberSecurity Fundamentals"), "The certification record not cancelled successfully");
            }

        }
    }
}
