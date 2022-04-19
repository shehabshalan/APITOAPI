using AnotherAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnotherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostcodeSourceController : ControllerBase
    {
        private readonly DataContext context;
        // s
        public PostcodeSourceController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Postcode>>> GetPostCodes()
        {
            return Ok(await context.Postcodes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Postcode>> GetPostCodeById(int id)
        {
            var country = await context.Postcodes.FindAsync(id);
            if (country == null)
                return BadRequest();

            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult<Postcode>> PostPostCode([FromBody] Postcode country)
        {
            context.Postcodes.Add(country);
            await context.SaveChangesAsync();
            return Ok(country);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Postcode>> DeletePostCode(int id)
        {
            var country = await context.Postcodes.FindAsync(id);
            context.Postcodes.Remove(country);
            await context.SaveChangesAsync();

            return Ok("deleted successfully");
        }
        [HttpPut]
        public async Task<ActionResult<Postcode>> UpdatePostCode([FromBody] Postcode request)
        {
            var country = await context.Postcodes.FindAsync(request.Id);
            if (country == null)
                return BadRequest();
            country.Code = request.Code;
            country.Country = request.Country;
            await context.SaveChangesAsync();
            return Ok(country);

        }
    }
}