using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnTinyCSVParser.Helpers;
using LearnTinyCSVParser.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnTinyCSVParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            var stream = System.IO.File.CreateText("Files/csvFile.csv");
            stream.WriteLine("Name,Address");
            stream.WriteLine("Joko,Malang");
            stream.WriteLine("Joni,Surabaya");
            stream.Close();
            return Ok();
        }

        [HttpGet("FromObject")]
        public ActionResult FromObject()
        {
            string headerCsv = "Name,Address";
            List<Product> products = GetProducts();

            var stream = System.IO.File.CreateText("Files/csvFile.csv");
            CreateCSV.Create(stream, headerCsv, products);
            stream.Close();


            return Ok();
        }
        private List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product
            {
                Name = "Dani",
                Description = "desc1"
            });
            products.Add(new Product
            {
                Name = "Ari",
                Description = "desc1"
            });
            return products;
        }
    }
}