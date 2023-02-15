using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase {
        // Properties
        private readonly IEntityRepo<ProductCategory> _productCategoryRepo;

        // Constructors
        public ProductCategoryController(IEntityRepo<ProductCategory> productCategoryRepo) {
            _productCategoryRepo = productCategoryRepo;
        }

        // GET: api/<ProductCategorysController>
        [HttpGet]
        public async Task<IEnumerable<ProductCategoryListDto>> Get() {
            var result = await Task.Run(() => { return _productCategoryRepo.GetAll(); });
            var selectProductCategoryList = result.Select(productCategory => new ProductCategoryListDto {
                Id = productCategory.Id,
                Code = productCategory.Code,
                Description = productCategory.Description,
                ProductType = productCategory.ProductType,
            });
            return selectProductCategoryList;
        }

        // GET: api/<ProductCategorysController>
        [HttpGet("{id}")]
        public async Task<ProductCategoryEditDto?> GetById(int id) {
            var result = await Task.Run(() => { return _productCategoryRepo.GetById(id); });
            if (result is null) {
                return null;
            }
            return new ProductCategoryEditDto {
                Id = id,
                Code = result.Code,
                Description = result.Description,
                ProductType = result.ProductType,
            };
        }

        // GET: api/<ProductsController>
        [Route("/productcategorylist/details/{id}")]
        [HttpGet]
        public async Task<ProductCategoryDetailsDto?> GetDetailsById(int id) {
            var result = await Task.Run(() => { return _productCategoryRepo.GetById(id); });
            if (result is null) {
                return null;
            } else {
                return new ProductCategoryDetailsDto {
                    Id = id,
                    Code = result.Code,
                    Description = result.Description,
                    ProductType = result.ProductType,
                    Products = result.Products.Select(products => new ProductListDto {
                        Code = products.Code,
                        Description = products.Description,
                        Cost = products.Cost,
                        Price = products.Price,
                    }).ToList()
                };
            }
        }


        // POST api/<ProductCategorysController>
        [HttpPost]
        public async Task Post(ProductCategoryEditDto productCategory) {
            var newProductCategory = new ProductCategory(productCategory.Code, productCategory.Description, productCategory.ProductType);
            await Task.Run(() => { _productCategoryRepo.Add(newProductCategory); });
        }

        // PUT api/<ProductCategorysController>/5
        [HttpPut]
        public async Task Put(ProductCategoryEditDto productCategory) {
            var dbProductCategory = await Task.Run(() => { return _productCategoryRepo.GetById(productCategory.Id); });
            if (dbProductCategory is null) {
                // TODO: if dbProductCategory is null
                return;
            }
            dbProductCategory.Code = productCategory.Code;
            dbProductCategory.Description = productCategory.Description;
            dbProductCategory.ProductType = productCategory.ProductType;
            _productCategoryRepo.Update(productCategory.Id, dbProductCategory);
        }

        // DELETE api/<ProductCategorysController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            await Task.Run(() => { _productCategoryRepo.Delete(id); });
        }
    }
}
