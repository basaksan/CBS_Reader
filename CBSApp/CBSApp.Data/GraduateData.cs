using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBSApp.Common;
using CBSApp.Data.Cvs;

namespace CBSApp.Data
{
    public class GraduateData
    {
        private IDataReader dataReader = new DataReader();
        
        public List<Graduate> Graduates { get; set; }

        public List<Category> Genders { get; set; }

        public List<Category> Ages { get; set; }

        public List<Category> Background { get; set; }

        public List<Category> EducationType { get; set; }

        public List<Category> Periods { get; set; }

        public List<Category> Regions { get; set; }
        
        public void Load()
        {
            Graduates = dataReader.LoadGraduates();
            Genders = dataReader.LoadGenders();
            Ages = dataReader.LoadAges();
            Background = dataReader.LoadBackground();
            EducationType = dataReader.LoadEducationType();
            Periods = dataReader.LoadPeriods();
            Regions = dataReader.LoadRegions();
        }
    }
}
