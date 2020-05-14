using LearnTinyCSVParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace LearnTinyCSVParser.Helpers
{
    public class CsvProductMapping : CsvMapping<Product>
    {
        public CsvProductMapping() : base()
        {
            MapProperty(0, x => x.Name);
            MapProperty(1, x => x.Description);
            MapProperty(2, x => x.Price);
        }
    }
}
