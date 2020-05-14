using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnTinyCSVParser.Helpers;
using LearnTinyCSVParser.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyCsvParser;

namespace LearnTinyCSVParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvProductMapping csvMapper = new CsvProductMapping();
            CsvParser<Product> csvParser = new CsvParser<Product>(csvParserOptions, csvMapper);
            var products = csvParser.ReadFromFile(@"C:\Project\testing2\"+ "Book1.csv", Encoding.ASCII).ToList();
            //products.RemoveAt(0);

            foreach (var product in products)
            {
                var result = product.Result;
            }

            return Ok("Oke");
        }
    }
}