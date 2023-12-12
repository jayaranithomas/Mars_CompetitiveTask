using CompetiviveTask_Mars.DataModel;
using CompetiviveTask_Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
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
        string Message = "";
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
            Message = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }
        public void DeleteAllEducationRecords()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='third']//tbody")).Count;

            for (int i = 1; i <= rowcount;)
            {

                IWebElement DeleteButton = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[1]//i[@class='remove icon']"));
                DeleteButton.Click();

                rowcount--;

                Thread.Sleep(1000);
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                Message = messageBox.Text;

                compare = "Education entry successfully removed";

                Console.WriteLine(Message);
                Assert.That(Message.Equals(compare), "The education record has not been deleted successfully");

                driver.Navigate().Refresh();
                profile.SelectEducationTab();

                Thread.Sleep(2000);

            }
        }

        public void AddNewEducationRecordWithAllNullData(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }

        public void AddNewEducationRecordWithDropdownNotSelected(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }

        public void AddNewEducationRecordWithValidDataInDropdownAndEmptyTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(2000);
            IWebElement addButton = driver.FindElement(By.XPath("//div[@data-tab='third']//input[1][@value='Add']"));
            addButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "Please enter all the fields";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }

        public void AddAlreadyExistingEducationRecord(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "This information is already exist.";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has been added successfully");

        }

        public void AddEducationRecordWithExistingDataInTextBoxesAndDifferentDropDown(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }
        public void AddEducationRecordWithExistingDataInDropDownAndDifferentTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }
        public void AddEducationRecordWithSpecialCharactersInCollegeTextBox(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }
        public void AddEducationRecordWithVeryLongDataInDegreeTextBox(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);
            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "Education has been added";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }
        public void AddEducationRecordWithSpacesInTextBoxes(string collegeName, string country, string title, string degree, string yearOfGrad)
        {

            AddEducation(collegeName, country, title, degree, yearOfGrad);

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

            compare = "Education information was invalid";

            Console.WriteLine(Message);
            Assert.That(Message.Equals(compare), "The education record has not been added successfully");

        }
        public void CancelAddEducationRecord(string collegeName, string country, string title, string degree, string yearOfGrad)
        {
            cancelFlag = 1;
            AddEducation(collegeName, country, title, degree, yearOfGrad);
            cancelFlag = 0;

            IWebElement CancelButton = driver.FindElement(By.XPath("//div[@data-tab='third']//input[@value='Cancel']"));
            CancelButton.Click();

            Thread.Sleep(1000);
            IWebElement lastRecord = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[last()]/tr/td[2]"));
            
            Assert.That(!lastRecord.Text.Equals("Monach"), "The education record not cancelled successfully");
          
        }
    }
}
