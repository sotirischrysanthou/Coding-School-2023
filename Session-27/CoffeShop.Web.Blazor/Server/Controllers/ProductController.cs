using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared;
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
        public async Task<IEnumerable<ProductListDto>?> Get() {
            var result = await Task.Run(() => { return _productRepo.GetAll(); });
            if(result is null) {
                return null;
            }
            var selectProductList = result.Select(product => new ProductListDto {
                Id = product.Id,
                Code = product.Code,
                Description = product.Description,
                Cost = product.Cost,
                Price = product.Price,
                ProductCategoryId = product.ProductCategoryId
            });
            return selectProductList;
        }

        // GET: api/<ProductsController>
        [HttpGet("{id}")]
        public async Task<ProductEditDto?> GetById(int id) {
            var result = await Task.Run(() => { return _productRepo.GetById(id); });
            if (result is null) {
                return null;
            } else {
                return new ProductEditDto {
                    Id = id,
                    Code = result.Code,
                    Description = result.Description,
                    Cost = result.Cost,
                    Price = result.Price,
                    ProductCategoryId = result.ProductCategoryId
                };
            }
        }

        // GET: api/<ProductsController>
        [Route("/productlist/details/{id}")]
        [HttpGet]
        public async Task<ProductDetailsDto?> GetDetailsById(int id)    {
            var result = await Task.Run(() => { return _productRepo.GetById(id); });
            if (result is null) {
                return null;
            } else {
                return new ProductDetailsDto {
                    Id = id,
                    Code = result.Code,
                    Description = result.Description,
                    Cost = result.Cost,
                    Price = result.Price,
                    ProductCategoryId = result.ProductCategoryId,
                    TransactionLines = result.TransactionLines.Select(transactionLine => new TransactionLineListDto {
                        Quantity = transactionLine.Quantity,
                        Discount = transactionLine.Discount,
                        Price = transactionLine.Price,
                        TotalPrice = transactionLine.TotalPrice,
                    }).ToList()
                };
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post(ProductEditDto product) {
            var newProduct = new Product(product.Code, product.Description, product.Price, product.Cost) {
                ProductCategoryId = product.ProductCategoryId,
            };
            await Task.Run(() => { _productRepo.Add(newProduct); });
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task Put(ProductEditDto product) {
            var dbProduct = await Task.Run(() => { return _productRepo.GetById(product.Id); });
            if (dbProduct is null) {
                // Todo: if dbProduct is null
                return;
            }
            dbProduct.Code = product.Code;
            dbProduct.Description = product.Description;
            dbProduct.Cost = product.Cost;
            dbProduct.Price = product.Price;
            dbProduct.ProductCategoryId = product.ProductCategoryId;
            dbProduct.ProductCategory = null!;
            _productRepo.Update(product.Id, dbProduct);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            await Task.Run(() => { _productRepo.Delete(id); });
        }
    }
}
