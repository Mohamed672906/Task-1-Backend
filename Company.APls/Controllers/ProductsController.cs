using Company.Core.Entites;
using Company.Core.Repository;
using Company.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.APls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly StoreContext _storeContext;

        public ProductsController(IGenericRepository<Product> ProductRepo, StoreContext storeContext)
        {
            _productRepo = ProductRepo;
            _storeContext = storeContext;
        }


        // -	GET /api/products: Retrieve a list of all products.

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var Products = await _productRepo.GetAllAsync();
            return Ok(Products);
        }




        // Get Product By Id 

        [HttpGet("{ID}")]

        public async Task<ActionResult<Product>> GetProductbyId(int Id)
        {
            var Products = await _productRepo.GetByIdAsync(Id);
            if (Products == null)
            {
                return NotFound();
            }
            return Ok(Products);

        }



        //-	POST /api/products: Add a new product.

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            await _productRepo.AddAsync(product);
            return CreatedAtAction(nameof(GetProductbyId), new { id = product.ProductId }, product);


        }


        //-	PUT /api/products/{id}: Update an existing product.

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Product ID mismatch.");
            }

            var existingProduct = await _productRepo.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            _productRepo.Update(product);
            await _storeContext.SaveChangesAsync(); 

            return NoContent();
        }





        //DELETE /api/products/{id}: Delete a product. 
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            _productRepo.Delete(product);
            await _storeContext.SaveChangesAsync();

            return NoContent();
        }












    }



}

