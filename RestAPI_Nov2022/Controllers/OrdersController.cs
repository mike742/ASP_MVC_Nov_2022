using Microsoft.AspNetCore.Mvc;
using RestAPI_Nov2022.Data.Interfaces;
using RestAPI_Nov2022.ModelsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI_Nov2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _repo;

        public OrdersController(IOrderRepo repo)
        {
            _repo = repo;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _repo.Get() );
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var res = _repo.Get(id);
                if (res == null)
                {
                    return NotFound("There is no Order with id = " + id);
                }
                return Ok( res );
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post(OrderCreateDto value)
        {
            try
            {
                _repo.Create(value);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderCreateDto value)
        {
            try
            {
                _repo.Update(id, value);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
