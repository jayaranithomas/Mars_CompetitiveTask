using CompetiviveTask_Mars.DataModel;
using CompetiviveTask_Mars.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetiviveTask_Mars.Utilities
{
    public class JSONReader
    {
        private readonly string jsonFilePath;
        public JSONReader(string sampleJsonFilePath)
        {
            jsonFilePath = sampleJsonFilePath;
        }

        public List<EducationDM> ReadJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();
            
            List<EducationDM> education = JsonConvert.DeserializeObject<List<EducationDM>>(json);
            return education;
        }
        public List<CertificationDM> ReadCJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();
           
            List<CertificationDM> certification = JsonConvert.DeserializeObject<List<CertificationDM>>(json);
            return certification;
        }
    }
}
