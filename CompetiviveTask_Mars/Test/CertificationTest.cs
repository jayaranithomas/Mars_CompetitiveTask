using CompetiviveTask_Mars.DataModel;
using CompetiviveTask_Mars.Pages;
using CompetiviveTask_Mars.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetiviveTask_Mars.Test
{
    [TestFixture]
    public class CertificationTest : CommonDriver
    {

        List<CertificationDM> certificationRecord = new List<CertificationDM>();
        CertificationPage certificationObj = new CertificationPage();
        ProfilePage profileObj = new ProfilePage();

        [OneTimeSetUp]
        public void ReadJSON()
        {
            JSONReader jsonObj = new JSONReader(@"F:\Jaya_IC\MarsTask2\Mars_CompetitiveTask\CompetiviveTask_Mars\TestData\Certificationdata.json");

            certificationRecord = jsonObj.ReadCJsonData();

        }


        [SetUp]
        public void SetUp()
        {            
            profileObj.SelectCertificationsTab();
        }


        [Test, Order(1), Description("This test deletes all Certification Records")]
        public void TestDeleteAllCertificationRecords()
        {

            certificationObj.DeleteAllCertificationRecords();

        }

        [Test, Order(2), Description("This test adds two new Certification Records")]
        public void TestCreateNewCertificationRecord()
        {

            for (int i = 0; i < 2; i++)
            {
                string year = certificationRecord[i].year;
                string certificateName = certificationRecord[i].certificateName;
                string certifiedFrom = certificationRecord[i].certifiedFrom;

                certificationObj.AddNewCertification(certificateName, certifiedFrom, year);
                Thread.Sleep(3000);
            }

        }
        [Test, Order(3), Description("This test adds new Certification Records with NULL data in all fields")]
        public void TestCreateNewCertificationRecordWithAllNullData()
        {


            string year = certificationRecord[2].year;
            string certificateName = certificationRecord[2].certificateName;
            string certifiedFrom = certificationRecord[2].certifiedFrom;


            certificationObj.AddNewCertificationRecordWithAllNullData(certificateName, certifiedFrom, year);
        }
        [Test, Order(4), Description("This test adds new Certification Records with NULL data in dropdowns and valid data in text boxes")]
        public void TestCreateNewCertificationRecordWithDropdownNotSelected()
        {


            string year = certificationRecord[3].year;
            string certificateName = certificationRecord[3].certificateName;
            string certifiedFrom = certificationRecord[3].certifiedFrom;

            certificationObj.AddNewCertificationRecordWithDropdownNotSelected(certificateName, certifiedFrom, year);

        }
        [Test, Order(5), Description("This test adds new Education Records with NULL data in text boxes and valid data in dropdowns")]
        public void TestCreateNewCertificationRecordWithValidDataInDropdownAndEmptyTextBoxes()
        {


            string year = certificationRecord[4].year;
            string certificateName = certificationRecord[4].certificateName;
            string certifiedFrom = certificationRecord[4].certifiedFrom;

            certificationObj.AddNewCertificationRecordWithValidDataInDropdownAndEmptyTextBoxes(certificateName, certifiedFrom, year);

        }
        [Test, Order(6), Description("This test adds an already existing Certification Record")]
        public void TestCreateAlreadyExistingCertificationRecord()
        {
            string year = certificationRecord[0].year;
            string certificateName = certificationRecord[0].certificateName;
            string certifiedFrom = certificationRecord[0].certifiedFrom;

            certificationObj.AddAlreadyExistingCertificationRecord(certificateName, certifiedFrom, year);

        }
        [Test, Order(7), Description("This test adds a Certification Record with already existing data in Text Boxes and selecting different year from dropdown")]
        public void TestCreateCertificationRecordWithExistingDataInTextBoxesAndDifferentDropDown()
        {
            string year = certificationRecord[5].year;
            string certificateName = certificationRecord[5].certificateName;
            string certifiedFrom = certificationRecord[5].certifiedFrom;

            certificationObj.AddCertificationRecordWithExistingDataInTextBoxesAndDifferentDropDown(certificateName, certifiedFrom, year);

        }
        [Test, Order(8), Description("This test adds an Certification Record with new data in Text Boxes and selecting already existing year from drop downs")]
        public void TestCreateEducationRecordWithExistingDataInDropDownAndDifferentTextBoxes()
        {
            string year = certificationRecord[6].year;
            string certificateName = certificationRecord[6].certificateName;
            string certifiedFrom = certificationRecord[6].certifiedFrom;

            certificationObj.AddCertificationRecordWithExistingDataInDropDownAndDifferentTextBoxes(certificateName, certifiedFrom, year);

        }
        [Test, Order(9), Description("This test adds a Certification Record with Special Characters and numbers in Certificate Name TextBox")]
        public void TestCreateEducationRecordWithSpecialCharactersInCollegeTextBox()
        {
            string year = certificationRecord[7].year;
            string certificateName = certificationRecord[7].certificateName;
            string certifiedFrom = certificationRecord[7].certifiedFrom;


            certificationObj.AddCertificationRecordWithSpecialCharactersInCertificationNameTextBox(certificateName, certifiedFrom, year);

        }
        [Test, Order(10), Description("This test adds a Certification Record with more than 500 characters in Certified From TextBox")]
        public void TestCreateCertificationRecordWithVeryLongDataInCertifiedFromTextBox()
        {
            string year = certificationRecord[8].year;
            string certificateName = certificationRecord[8].certificateName;
            string certifiedFrom = certificationRecord[8].certifiedFrom;

            certificationObj.AddCertificationRecordWithVeryLongDataInCertifiedFromTextBox(certificateName, certifiedFrom, year);

        }
        [Test, Order(11), Description("This test adds a Certification Record with Spaces in TextBoxes")]
        public void TestCreateCertificationRecordWithSpacesInTextBoxes()
        {
            string year = certificationRecord[9].year;
            string certificateName = certificationRecord[9].certificateName;
            string certifiedFrom = certificationRecord[9].certifiedFrom;

            certificationObj.AddCertificationRecordWithSpacesInTextBoxes(certificateName, certifiedFrom, year);

        }
        [Test, Order(12), Description("This test cancels a Certification Record without adding")]
        public void TestCancelAddCertificationRecord()
        {
            string year = certificationRecord[10].year;
            string certificateName = certificationRecord[10].certificateName;
            string certifiedFrom = certificationRecord[10].certifiedFrom;


            certificationObj.CancelAddCertificationRecord(certificateName, certifiedFrom, year);

        }
        [Test, Order(13), Description("This test updates an existing Certification Record with all fields edited")]
        public void TestUpdateCertificationRecordWithAllFieldsEdited()
        {
            string year = certificationRecord[10].year;
            string certificateName = certificationRecord[10].certificateName;
            string certifiedFrom = certificationRecord[10].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithAllFieldsEdited(certificateName, certifiedFrom, year);

        }
        [Test, Order(14), Description("This test updates an existing Certification Record without editing any of the fields")]
        public void TestUpdateCertificationRecordWithNoFieldsEdited()
        {
            certificationObj.UpdateExistingCertificationRecordWithoutEditingAnyFields();

        }
        [Test, Order(15), Description("This test updates an existing Certification Record with NULL values in all fields")]
        public void TestUpdateCertificationRecordWithNULLValuesInAllFields()
        {
            string year = certificationRecord[2].year;
            string certificateName = certificationRecord[2].certificateName;
            string certifiedFrom = certificationRecord[2].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithNULLValuesInAllFields(certificateName, certifiedFrom, year);

        }
        [Test, Order(16), Description("This test updates an existing Certification Record with NULL data in text boxes and valid data in dropdowns")]
        public void TestUpdateCertificationRecordWithNULLValuesTextBoxesAndValidInDropdowns()
        {
            string year = certificationRecord[4].year;
            string certificateName = certificationRecord[4].certificateName;
            string certifiedFrom = certificationRecord[4].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithNULLValuesTextBoxesAndValidInDropdowns(certificateName, certifiedFrom, year);

        }
        [Test, Order(17), Description("This test updates an existing Certification Record with NULL data in dropdowns and valid data in text boxes")]
        public void TestUpdateCertificationRecordWithoutSelectingDropdownsAndEditingTextBoxes()
        {
            string year = certificationRecord[3].year;
            string certificateName = certificationRecord[3].certificateName;
            string certifiedFrom = certificationRecord[3].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithoutSelectingDropdownsAndEditingTextBoxes(certificateName, certifiedFrom, year);

        }
        [Test, Order(18), Description("This test updates an existing Certification Record without changing the Text Box values and editing dropdowns")]
        public void TestUpdateCertificationRecordWithoutChangingTextBoxesAndEditingDropdowns()
        {
            string year = certificationRecord[11].year;
            string certificateName = certificationRecord[11].certificateName;
            string certifiedFrom = certificationRecord[11].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithoutChangingTextBoxesAndEditingDropdowns(certificateName, certifiedFrom, year);

        }
        [Test, Order(19), Description("This test updates an existing Certification Record without changing the dropdown values but editing textboxes")]
        public void TestUpdateCertificationRecordWithoutChangingDropdownsAndEditingTextBoxes()
        {
            string year = certificationRecord[12].year;
            string certificateName = certificationRecord[12].certificateName;
            string certifiedFrom = certificationRecord[12].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithoutChangingDropdownsAndEditingTextBoxes(certificateName, certifiedFrom, year);

        }
        [Test, Order(20), Description("This test updates an existing Certification Record with special characters and numbers in Certification Name Field")]
        public void TestUpdateCertificationRecordWithSpecialCharactersInCollegeTextBox()
        {
            string year = certificationRecord[13].year;
            string certificateName = certificationRecord[13].certificateName;
            string certifiedFrom = certificationRecord[13].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithSpecialCharactersInCollegeTextBox(certificateName, certifiedFrom, year);

        }
        [Test, Order(21), Description("This test updates an existing Certification Record with more than 500 characters in Certified From textbox")]
        public void TestUpdateCertificationRecordWithVeryLongDataInDegreeTextBox()
        {
            string year = certificationRecord[14].year;
            string certificateName = certificationRecord[14].certificateName;
            string certifiedFrom = certificationRecord[14].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithVeryLongDataInCertifiedFromTextBox(certificateName, certifiedFrom, year);

        }
        [Test, Order(22), Description("This test updates a Certification Record with Spaces in TextBoxes")]
        public void TestUpdateCertificationRecordWithSpacesInTextBoxes()
        {
            string year = certificationRecord[15].year;
            string certificateName = certificationRecord[15].certificateName;
            string certifiedFrom = certificationRecord[15].certifiedFrom;

            certificationObj.UpdateExistingCertificationRecordWithSpacesInTextBoxes(certificateName, certifiedFrom, year);

        }
        [Test, Order(23), Description("This test cancels a Certification Record without updating")]
        public void TestCancelUpdateCertificationRecord()
        {
            string year = certificationRecord[10].year;
            string certificateName = certificationRecord[10].certificateName;
            string certifiedFrom = certificationRecord[10].certifiedFrom;

            certificationObj.CancelUpdateCertificationRecord(certificateName, certifiedFrom, year);

        }
    }

}
