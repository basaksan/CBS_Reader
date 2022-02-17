using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSApp.Common
{
    public interface IDataReader
    {
        List<Graduate> LoadGraduates();
        List<Category> LoadGenders();
        List<Category> LoadAges();
        List<Category> LoadBackground();
        List<Category> LoadEducationType();
        List<Category> LoadPeriods();
        List<Category> LoadRegions();
    }
}
