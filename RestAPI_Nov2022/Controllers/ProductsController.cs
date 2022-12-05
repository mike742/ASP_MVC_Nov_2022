using Microsoft.AspNetCore.Mvc;
using RestAPI_Nov2022.Data.Interfaces;
using RestAPI_Nov2022.Models;
using RestAPI_Nov2022.ModelsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI_Nov2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductsController(IProductRepo repo)
        {
            _productRepo = repo;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productRepo.Get());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductReadDto res = _productRepo.Get(id);

                if (res == null)
                {
                    return NotFound("There is no Product with id = " + id);
                }

                return Ok(res);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post(ProductCreateDto value)
        {
            try
            {
                _productRepo.Create(value);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductCreateDto value)
        {
            try
            {
                _productRepo.Update(id, value);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productRepo.Delete(id);
        }
    }
}
