using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStorageLibrary;
using AzureStorageLibrary.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("nosql")]
    public class NoSqlController : Controller
    {
        private readonly INoSqlStorage<Product> _noSqlStorage;

        public NoSqlController(INoSqlStorage<Product> noSqlStorage)
        {
            _noSqlStorage = noSqlStorage;
        }

        [HttpGet("getdatanosql")]
        public IActionResult GetData()
        {
            var list = _noSqlStorage.All().ToList();
            return Ok(list);
        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            //SQL serverden gelen ürün id'de olabilirdir
            product.RowKey = Guid.NewGuid().ToString();
            product.PartitionKey = "USB";
            await _noSqlStorage.Add(product);
            return Ok();
        }

        [HttpPut("updateproduct")]// sonraya kaldı
        public async Task<IActionResult> Update(Product product, string rowKey, string partitionKey)
        {
            var products = await _noSqlStorage.Get(rowKey, partitionKey);

            await _noSqlStorage.Update(products);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> Delete([FromQuery] string rowkey, string partitionKey)
        {
            
            await _noSqlStorage.Delete(rowkey, partitionKey);
            return Ok();
        }

        [HttpGet("getbyprice")]
        public IActionResult GetProductById([FromQuery] double price)
        {
            var result = _noSqlStorage.Query(x => x.Price > price).ToList();
            return Ok(result);
        }


    }
}
