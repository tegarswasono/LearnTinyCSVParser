using LearnTinyCSVParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LearnTinyCSVParser.Helpers
{
    public static class CreateCSV
    {
        public static void Create(StreamWriter stream, string header, List<Product> products)
        {
            stream.WriteLine(header);
            foreach (var product in products)
            {
                stream.WriteLine(product.Name + "," + product.Description);
            }
        }
    }
}
