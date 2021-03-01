using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Products.Data;
using Products.Repo;
using Products.Services;


namespace InventoryWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // call the repo using this controller
        //link controller to database
 

        readonly IProduct db;
       
        public ProductController(IProduct _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult Save([FromBody] Product data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            db.Save(data);

            return Ok(data);


        }




        [HttpGet("{Id}")]
        public IActionResult GetProduct(int? Id)
        {
            Product data = db.GetProduct(Id);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            IQueryable<Product> data = db.GetProducts;
            return Ok(data);
        }
   

        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            db.Delete(Id);
            return Ok();
        }


       


    }
}
