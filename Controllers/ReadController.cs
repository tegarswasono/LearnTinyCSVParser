using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpPost]
        public async Task<ActionResult> Post(IFormFile file)
        {
            try
            {
                string[] permittedExtensions = { ".csv" };
                var ext = System.IO.Path.GetExtension(file.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    return BadRequest("Only Allowed CSV File");

                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
                CsvProductMapping csvMapper = new CsvProductMapping();
                CsvParser<Product> csvParser = new CsvParser<Product>(csvParserOptions, csvMapper);
                var products = csvParser.ReadFromStream(file.OpenReadStream(), Encoding.ASCII).ToList();

                foreach (var product in products)
                {
                    var result = product.Result;
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}