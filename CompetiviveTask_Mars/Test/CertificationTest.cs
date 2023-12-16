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


        [OneTimeSetUp]
        public void ReadJSON()
        {
            JSONReader jsonObj = new JSONReader(@"F:\Jaya_IC\MarsTask2\Mars_CompetitiveTask\CompetiviveTask_Mars\TestData\Certificationdata.json");

            certificationRecord = jsonObj.ReadCJsonData();

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
                string year = certificationRecord[i].Year;
                string certificateName = certificationRecord[i].CertificateName;
                string certifiedFrom = certificationRecord[i].CertifiedFrom;
               
                certificationObj.AddNewCertification(certificateName, certifiedFrom, year);

            }

        }
    }
}