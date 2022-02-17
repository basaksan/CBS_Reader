using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cbs.OData.Catalog;

namespace CBSApp.Data.OData
{
    public class CbsClient
    {
        public List<string> GetCatalog()
        {
            Catalog dsc = new Catalog(new Uri("https://opendata.cbs.nl/ODataCatalog/"));

            //var me = dsc.Entities.Select(x => x.Identity).ToList();
            //var titlesResource = dsc.Themes.Select(t => new { t.Title }).ToList();
            //return titlesResource.Select(r => r.Title).ToList();

            var titlesResource = dsc.Tables.Select(t => new { t.Title, t.ShortDescription, t.ColumnCount, t.RecordCount, t.FeedUrl, t.Source, t.ApiUrl }).ToList();
            var list = titlesResource.Select(r => r.Title + " - " + r.FeedUrl).ToList();



            //var client = new ODataClient("https://opendata.cbs.nl/ODataCatalog/");








            return list;
        }
    }
}
