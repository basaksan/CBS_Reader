using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBSApp.Common;
using CBSApp.Data.Cvs;

namespace CBSApp
{
    public class GraduateData
    {
        private IDataReader dataReader = new DataReader();

        public List<Graduate> Graduates { get; set; }

        public List<Graduate> GraduatesReadable { get; set; }

        public List<Graduate> Grouped { get; set; }

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

            Join();
        }

        public void Join()
        {
            var join =
                from g in Graduates
                join gender in Genders on g.Geslacht equals gender.Key
                join age in Ages on g.Leeftijd equals age.Key
                join b in Background on g.Migratieachtergrond equals b.Key
                join e in EducationType on g.Onderwijssoort equals e.Key
                //join p in Periods on g.Perioden equals p.Key
                join r in Regions on g.RegioS equals r.Key
                select new Graduate
                {
                    ID = g.ID,
                    Geslacht = gender.Title,
                    Leeftijd = age.Title,
                    Migratieachtergrond = b.Title,
                    Onderwijssoort = e.Title,
                    Perioden = g.Perioden, //Perioden = p.Title,
                    RegioS = r.Title,
                    Gediplomeerden_1 = g.Gediplomeerden_1
                };

            GraduatesReadable = join.ToList();
        }

        public void GroupBy()
        {
            //List<ResultLine> result = Graduates
            //    .GroupBy(g => g.Onderwijssoort)
            //    .Select(cl => new ResultLine
            //    {
            //        ProductName = cl.First().Name,
            //        Quantity = cl.Count().ToString(),
            //        Price = cl.Sum(c => c.Price).ToString(),
            //    }).ToList();
        }
    }
}
