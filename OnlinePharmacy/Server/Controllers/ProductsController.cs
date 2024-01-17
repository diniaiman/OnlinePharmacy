using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePharmacy.Server.IRepository;
using OnlinePharmacy.Shared.Domain;
using System.Drawing;

namespace OnlinePharmacy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsControllers : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsControllers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.Get(q => q.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(product).State = EntityState.Modified;
            _unitOfWork.Products.Update(product);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostCustomer(Product product)
        {
            await _unitOfWork.Products.Insert(product);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
        private async Task<bool> ProductExists(int id)
        {
            var product = await _unitOfWork.Products.Get(q => q.Id == id);
            return product != null;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var customer = await _unitOfWork.Products.Get(q => q.Id == id);
            if (customer == null)
            {
                return NotFound();
            }


            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
    }
}
