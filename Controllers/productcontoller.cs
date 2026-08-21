using learningprojectserver.models;
using learningprojectserver.Services;
using Microsoft.AspNetCore.Mvc;

namespace learningprojectserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productcontoller : ControllerBase
    {
       public Productservice productservice;
        public Productcontoller(Productservice productservice) {

             this.productservice = productservice;

        }

        [HttpPost("Select")]
          public  async Task<ActionResult<Product>> Select(Product product)    
            {

            List<Product> result = new List<Product>();

            result = await productservice.select(product);

            return Ok(result);

        }
       
      

    }
}
