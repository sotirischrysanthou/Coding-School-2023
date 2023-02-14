using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared.ProductCategory;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers
{
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
            var result = _productCategoryRepo.GetAll();
            var selectProductCategoryList= result.Select(productCategory => new ProductCategoryListDto {
                Id = productCategory.Id,
                Code = productCategory.Code,
                Description = productCategory.Description,
                ProductType = productCategory.ProductType,
            });
            return selectProductCategoryList;
        }

        // GET: api/<ProductCategorysController>
        [HttpGet("{id}")]
        public async Task<ProductCategoryEditDto> GetById(int id) {
            var result = _productCategoryRepo.GetById(id);
            return new ProductCategoryEditDto {
                Id = id,
                Code = result.Code,
                Description = result.Description,
                ProductType = result.ProductType,
            };
        }

        // POST api/<ProductCategorysController>
        [HttpPost]
        public async Task Post(ProductCategoryEditDto productCategory) {
            var newProductCategory = new ProductCategory(productCategory.Code, productCategory.Description, productCategory.ProductType);
            _productCategoryRepo.Add(newProductCategory);
        }

        // PUT api/<ProductCategorysController>/5
        [HttpPut]
        public async Task Put(ProductCategoryEditDto productCategory) {
            var dbProductCategory = _productCategoryRepo.GetById(productCategory.Id);
            dbProductCategory.Code = productCategory.Code;
            dbProductCategory.Description = productCategory.Description;
            dbProductCategory.ProductType = productCategory.ProductType;
            _productCategoryRepo.Update(productCategory.Id, dbProductCategory);
        }

        // DELETE api/<ProductCategorysController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            _productCategoryRepo.Delete(id);
        }
    }
}
