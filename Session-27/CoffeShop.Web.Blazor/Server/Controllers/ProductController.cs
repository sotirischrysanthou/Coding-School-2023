using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared.Product;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Product> _productRepo;

        // Constructors
        public ProductController(IEntityRepo<Product> productRepo) {
            _productRepo = productRepo;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<ProductListDto>> Get() {
            var result = _productRepo.GetAll();
            var selectProductList = result.Select(product => new ProductListDto {
                Id = product.Id,
                Code = product.Code,
                Description = product.Description,
                Cost = product.Cost,
                Price = product.Price,


            });
            return selectProductList;
        }

        // GET: api/<ProductsController>
        [HttpGet("{id}")]
        public async Task<ProductEditDto> GetById(int id) {
            var result = _productRepo.GetById(id);
            return new ProductEditDto {
                Id = id,
                Code = result.Code,
                Description = result.Description,
                Cost = result.Cost,
                Price = result.Price,
            };
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post(ProductEditDto product) {
            var newProduct = new Product(product.Code, product.Description, product.Price, product.Cost);
            _productRepo.Add(newProduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task Put(ProductEditDto product) {
            var dbProduct = _productRepo.GetById(product.Id);
            dbProduct.Code = product.Code;
            dbProduct.Description = product.Description;
            dbProduct.Cost = product.Cost;
            dbProduct.Price = product.Price;
            _productRepo.Update(product.Id, dbProduct);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            _productRepo.Delete(id);
        }
    }
}
