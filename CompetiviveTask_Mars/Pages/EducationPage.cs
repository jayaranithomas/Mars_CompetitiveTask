using CompetiviveTask_Mars.DataModel;
using CompetiviveTask_Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetiviveTask_Mars.Pages
{
    public class EducationPage : CommonDriver
    {
        string popupMessage = "";
        string compare = "";

        int cancelFlag = 0;
        ProfilePage profile = new ProfilePage();

        public void AddEducation(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='third']//div[contains(text(),'Add New')]"));
            addNewButton.Click();

            if (!string.IsNullOrEmpty(collegeName))
            {
                IWebElement addCollegeTextBox = driver.FindElement(By.Name("instituteName"));
                addCollegeTextBox.Click();
                addCollegeTextBox.SendKeys(collegeName);
            }
            if (!string.IsNullOrEmpty(country))
            {
                IWebElement chooseCountryDD = driver.FindElement(By.Name("country"));
                chooseCountryDD.Click();
                chooseCountryDD.SendKeys(country);
            }
            if (!string.IsNullOrEmpty(title))
            {
                IWebElement chooseTitleDD = driver.FindElement(By.Name("title"));
                chooseTitleDD.Click();
                chooseTitleDD.SendKeys(title);
            }
            if (!string.IsNullOrEmpty(degree))
            {
                IWebElement addDegreeTextBox = driver.FindElement(By.Name("degree"));
                addDegreeTextBox.Click();
                addDegreeTextBox.SendKeys(degree);
            }
            if (!string.IsNullOrEmpty(yearOfGrad))
            {
                IWebElement chooseYearDD = driver.FindElement(By.Name("yearOfGraduation"));
                chooseYearDD.Click();
                chooseYearDD.SendKeys(yearOfGrad);
                chooseYearDD.Click();
            }
            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                IWebElement addButton = driver.FindElement(By.XPath("//div[@data-tab='third']//input[1][@value='Add']"));
                addButton.Click();
            }
        }
        public void AddNewEducation(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");
           
        }
        public void DeleteAllEducationRecords()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='third']//tbody")).Count;

            for (int i = 1; i <= rowcount;)
            {

                IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[1]//i[@class='remove icon']"));
                deleteButton.Click();

                rowcount--;

                Thread.Sleep(1000);
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                popupMessage = messageBox.Text;

                compare = "Education entry successfully removed";

                Console.WriteLine(popupMessage);
                Assert.That(popupMessage.Equals(compare), "The education record has not been deleted successfully");

                Thread.Sleep(2000);
               
            }
        }

        public void AddNewEducationRecordWithAllNullData(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");
           
        }

        public void AddNewEducationRecordWithDropdownNotSelected(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");
           
        }

        public void AddNewEducationRecordWithValidDataInDropdownAndEmptyTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(2000);
            IWebElement addButton = driver.FindElement(By.XPath("//div[@data-tab='third']//input[1][@value='Add']"));
            addButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");

        }

        public void AddAlreadyExistingEducationRecord(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "This information is already exist.";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has been added successfully");

        }

        public void AddEducationRecordWithExistingDataInTextBoxesAndDifferentDropDown(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");

        }
        public void AddEducationRecordWithExistingDataInDropDownAndDifferentTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");

        }
        public void AddEducationRecordWithSpecialCharactersInCollegeTextBox(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");

        }
        public void AddEducationRecordWithVeryLongDataInDegreeTextBox(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");

        }
        public void AddEducationRecordWithSpacesInTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education information was invalid";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been added successfully");

        }
        public void CancelAddEducationRecord(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            cancelFlag = 1;
            AddEducation(collegeName, country, title, degree, yearOfGrad);
            cancelFlag = 0;

            IWebElement cancelButton = driver.FindElement(By.XPath("//div[@data-tab='third']//input[@value='Cancel']"));
            cancelButton.Click();

            Thread.Sleep(1000);
            IWebElement lastRecord = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[last()]/tr/td[2]"));

            if (!lastRecord.Text.Equals("Monach"))
            {
                Console.WriteLine("Education record cancelled before adding");
                Assert.That(!lastRecord.Text.Equals("Monach"), "The education record not cancelled successfully");
            }

        }
        public void EditEducationRecord(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            Wait.WaitToBeClickable("XPath", "//div[@data-tab='third']//tbody[1]//i[@class='outline write icon']", 3);

            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            IWebElement collegeTextBox = driver.FindElement(By.Name("instituteName"));
            IWebElement degreeTextBox = driver.FindElement(By.Name("degree"));
            IWebElement chooseCountryDD = driver.FindElement(By.Name("country"));
            IWebElement chooseTitleDD = driver.FindElement(By.Name("title"));
            IWebElement chooseYearDD = driver.FindElement(By.Name("yearOfGraduation"));

            if (string.IsNullOrEmpty(collegeName))
            {
                var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                actions.Click(collegeTextBox);
                actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                actions.Perform();
            }
            else
            {
                collegeTextBox.Clear();
                collegeTextBox.SendKeys(collegeName);
            }
            if (string.IsNullOrEmpty(degree))
            {
                var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                actions.Click(degreeTextBox);
                actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                actions.Perform();
            }
            else
            {
                degreeTextBox.Clear();
                degreeTextBox.SendKeys(degree);
            }

            chooseCountryDD.Click();
            if (!string.IsNullOrEmpty(country))
                chooseCountryDD.SendKeys(country);
                        
            else
                chooseCountryDD.SendKeys("Country of College / University");
            chooseCountryDD.Click();

            chooseTitleDD.Click();
            if (!string.IsNullOrEmpty(title))
                chooseTitleDD.SendKeys(title);
            else
                chooseTitleDD.SendKeys("Title");
            chooseTitleDD.Click();

            chooseYearDD.Click();
            if (!string.IsNullOrEmpty(yearOfGrad))
                chooseYearDD.SendKeys(yearOfGrad);
            else
                chooseYearDD.SendKeys("Year of graduation");
            chooseYearDD.Click();

            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                IWebElement updateButton = driver.FindElement(By.XPath("//div[@data-tab='third']//input[@value='Update']"));
                updateButton.Click();
            }
        }
        public void UpdateExistingEducationRecordWithAllFieldsEdited(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education as been updated";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been updated successfully");
        }
        public void UpdateExistingEducationRecordWithoutEditingAnyFields()
        {
            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//div[@data-tab='third']//input[@value='Update']"));
            updateButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "This information is already exist.";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "Already existing education record updated");

        }
        public void UpdateExistingEducationRecordWithNULLValuesInAllFields(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has been updated");
        }
        public void UpdateExistingEducationRecordWithNULLValuesTextBoxesAndValidInDropdowns(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has been updated");
        }
        public void UpdateExistingEducationRecordWithoutSelectingDropdownsAndEditingTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(5000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has been updated");
        }
        public void UpdateExistingEducationRecordWithoutChangingTextBoxesAndEditingDropdowns(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(5000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education as been updated";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been updated");
        }
        public void UpdateExistingEducationRecordWithoutChangingDropdownsAndEditingTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(5000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education as been updated";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been updated");
        }
        public void UpdateExistingEducationRecordWithSpecialCharactersInCollegeTextBox(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(5000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education as been updated";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been updated");
        }
        public void UpdateExistingEducationRecordWithVeryLongDataInDegreeTextBox(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(5000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education as been updated";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has not been updated");
        }
        public void UpdateExistingEducationRecordWithSpacesInTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(5000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            popupMessage = messageBox.Text;

            compare = "Education information was invalid";

            Console.WriteLine(popupMessage);
            Assert.That(popupMessage.Equals(compare), "The education record has been updated");
        }
        public void CancelUpdateEducationRecord(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            cancelFlag = 1;
            EditEducationRecord(collegeName, country, title, degree, yearOfGrad);
            cancelFlag = 0;

            IWebElement cancelButton = driver.FindElement(By.XPath("//div[@data-tab='third']//input[@value='Cancel']"));
            cancelButton.Click();

            Thread.Sleep(1000);
            IWebElement firstRecord = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[1]/tr/td[2]"));

            if (!firstRecord.Text.Equals("Monach"))
            {
                Console.WriteLine("Education record cancelled before updating");
                Assert.That(!firstRecord.Text.Equals("Monach"), "The education record not cancelled successfully");
            }

        }
    }
}
