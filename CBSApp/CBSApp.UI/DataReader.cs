using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBSApp.Common;
using LINQtoCSV;
using NLog;

namespace CBSApp.Data.Cvs
{
    public class DataReader : IDataReader
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = true,
                FileCultureName = "en-US" // default is the current culture
            };
        
        private readonly CsvContext cc = new CsvContext();

        public List<Graduate> LoadGraduates()
        {
            var list = new List<Graduate>();
            CsvContext cc = new CsvContext();
            try
            {
                IEnumerable<Graduate> persons = cc.Read<Graduate>("../../../Data/71493ned_UntypedDataSet_16022022_201029.csv", inputFileDescription);
                list = persons.ToList();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }

            return list;
        }

        public List<Category> LoadGenders()
        {
            return LoadCategory("Geslacht.csv");
        }

        public List<Category> LoadAges()
        {
            return LoadCategory("Leeftijd.csv");
        }

        public List<Category> LoadBackground()
        {
            return LoadCategory("Migratieachtergrond.csv");
        }

        public List<Category> LoadEducationType()
        {
            return LoadCategory("Onderwijssoort.csv");
        }

        public List<Category> LoadPeriods()
        {
            return LoadCategory("Perioden.csv");
        }

        public List<Category> LoadRegions()
        {
            return LoadCategory("Regios.csv");
        }
        
        private List<Category> LoadCategory(string fileName)
        {
            var list = new List<Category>();
            try
            {
                IEnumerable<Category> data = cc.Read<Category>("../../../Data/" + fileName, inputFileDescription);
                list = data.ToList();

                //IEnumerable<Category> genders = cc.Read<Category>("../../../Data/Geslacht.csv", inputFileDescription);
                //IEnumerable<Category> ages = cc.Read<Category>("../../../Data/Leeftijd.csv", inputFileDescription);
                //IEnumerable<Category> migrationBackgrounds = cc.Read<Category>("../../../Data/Migratieachtergrond.csv", inputFileDescription);
                //IEnumerable<Category> educationTypes = cc.Read<Category>("../../../Data/Onderwijssoort.csv", inputFileDescription);
                //IEnumerable<Category> periods = cc.Read<Category>("../../../Data/Perioden.csv", inputFileDescription);
                //IEnumerable<Category> regions = cc.Read<Category>("../../../Data/Regios.csv", inputFileDescription);
                //IEnumerable<Category> categories = cc.Read<Category>("../../../Data/CategoryGroups.csv", inputFileDescription);

            }
            catch (Exception e)
            {
                logger.Error(e);
            }

            return list;
        }
    }
}
