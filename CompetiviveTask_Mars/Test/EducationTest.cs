
using CompetiviveTask_Mars.DataModel;
using CompetiviveTask_Mars.Pages;
using CompetiviveTask_Mars.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace CompetiviveTask_Mars.Test
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {

        List<EducationDM> educationRecord = new List<EducationDM>();
        EducationPage educationObj = new EducationPage();


        [OneTimeSetUp]
        public void ReadJSON()
        {
            JSONReader jsonObj = new JSONReader(@"F:\Jaya_IC\MarsTask2\Mars_CompetitiveTask\CompetiviveTask_Mars\TestData\data.json");

            educationRecord = jsonObj.ReadJsonData();

        }


        [SetUp]
        public void SetUp()
        {
            HomePage homeObj = new HomePage();
            LoginPage loginObj = new LoginPage();
            ProfilePage profileObj = new ProfilePage();

            Initialize();
            homeObj.SignInAction();
            loginObj.LoginActions();
            Thread.Sleep(3000);

            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            profileObj.SelectEducationTab();



        }


        [Test, Order(1), Description("This test deletes all Education Records")]
        public void TestDeleteAllEducationRecords()
        {

            educationObj.DeleteAllEducationRecords();

        }

        [Test, Order(2), Description("This test adds two new Education Records")]
        public void TestCreateNewEducationRecord()
        {

            for (int i = 0; i < 2; i++)
            {
                string year = educationRecord[i].Year;
                string college = educationRecord[i].College;
                string country = educationRecord[i].Country;
                string title = educationRecord[i].Title;
                string degree = educationRecord[i].Degree;


                educationObj.AddNewEducation(college, country, title, degree, year);

            }


        }

        [Test, Order(3), Description("This test adds new Education Records with NULL data in all fields")]
        public void TestCreateNewEducationRecordWithAllNullData()
        {


            string year = educationRecord[2].Year;
            string college = educationRecord[2].College;
            string country = educationRecord[2].Country;
            string title = educationRecord[2].Title;
            string degree = educationRecord[2].Degree;


            educationObj.AddNewEducationRecordWithAllNullData(college, country, title, degree, year);


        }

        [Test, Order(4), Description("This test adds new Education Records with NULL data in dropdowns and valid data in text boxes")]
        public void TestCreateNewEducationRecordWithDropdownNotSelected()
        {


            string year = educationRecord[3].Year;
            string college = educationRecord[3].College;
            string country = educationRecord[3].Country;
            string title = educationRecord[3].Title;
            string degree = educationRecord[3].Degree;

            educationObj.AddNewEducationRecordWithDropdownNotSelected(college, country, title, degree, year);


        }

        [Test, Order(5), Description("This test adds new Education Records with NULL data in text boxes and valid data in dropdowns")]
        public void TestCreateNewEducationRecordWithValidDataInDropdownAndEmptyTextBoxes()
        {


            string year = educationRecord[4].Year;
            string college = educationRecord[4].College;
            string country = educationRecord[4].Country;
            string title = educationRecord[4].Title;
            string degree = educationRecord[4].Degree;

            educationObj.AddNewEducationRecordWithValidDataInDropdownAndEmptyTextBoxes(college, country, title, degree, year);


        }
        [Test, Order(6), Description("This test adds an already existing Education Record")]
        public void TestCreateAlreadyExistingEducationRecord()
        {
            string year = educationRecord[0].Year;
            string college = educationRecord[0].College;
            string country = educationRecord[0].Country;
            string title = educationRecord[0].Title;
            string degree = educationRecord[0].Degree;

            educationObj.AddAlreadyExistingEducationRecord(college, country, title, degree, year);

        }
        [Test, Order(7), Description("This test adds an Education Record with already existing data in Text Boxes and selecting different drop downs")]
        public void TestCreateEducationRecordWithExistingDataInTextBoxesAndDifferentDropDown()
        {
            string year = educationRecord[5].Year;
            string college = educationRecord[5].College;
            string country = educationRecord[5].Country;
            string title = educationRecord[5].Title;
            string degree = educationRecord[5].Degree;

            educationObj.AddEducationRecordWithExistingDataInTextBoxesAndDifferentDropDown(college, country, title, degree, year);

        }
        [Test, Order(8), Description("This test adds an Education Record with new data in Text Boxes and selecting already existing drop downs")]
        public void TestCreateEducationRecordWithExistingDataInDropDownAndDifferentTextBoxes()
        {
            string year = educationRecord[6].Year;
            string college = educationRecord[6].College;
            string country = educationRecord[6].Country;
            string title = educationRecord[6].Title;
            string degree = educationRecord[6].Degree;

            educationObj.AddEducationRecordWithExistingDataInDropDownAndDifferentTextBoxes(college, country, title, degree, year);

        }

        [Test, Order(9), Description("This test adds an Education Record with Special Characters in College TextBox")]
        public void TestCreateEducationRecordWithSpecialCharactersInCollegeTextBox()
        {
            string year = educationRecord[7].Year;
            string college = educationRecord[7].College;
            string country = educationRecord[7].Country;
            string title = educationRecord[7].Title;
            string degree = educationRecord[7].Degree;

            educationObj.AddEducationRecordWithSpecialCharactersInCollegeTextBox(college, country, title, degree, year);

        }
        [Test, Order(10), Description("This test adds an Education Record with more than 500 characters in Degree TextBox")]
        public void TestCreateEducationRecordWithVeryLongDataInDegreeTextBox()
        {
            string year = educationRecord[8].Year;
            string college = educationRecord[8].College;
            string country = educationRecord[8].Country;
            string title = educationRecord[8].Title;
            string degree = educationRecord[8].Degree;

            educationObj.AddEducationRecordWithVeryLongDataInDegreeTextBox(college, country, title, degree, year);

        }
        [Test, Order(11), Description("This test adds an Education Record with Spaces in TextBoxes")]
        public void TestCreateEducationRecordWithSpacesInTextBoxes()
        {
            string year = educationRecord[9].Year;
            string college = educationRecord[9].College;
            string country = educationRecord[9].Country;
            string title = educationRecord[9].Title;
            string degree = educationRecord[9].Degree;

            educationObj.AddEducationRecordWithSpacesInTextBoxes(college, country, title, degree, year);

        }
        [Test, Order(12), Description("This test cancels an Education Record without adding")]
        public void TestCancelEducationRecord()
        {
            string year = educationRecord[10].Year;
            string college = educationRecord[10].College;
            string country = educationRecord[10].Country;
            string title = educationRecord[10].Title;
            string degree = educationRecord[10].Degree;

            educationObj.CancelAddEducationRecord(college, country, title, degree, year);

        }
    }
}
