using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        [HttpPost("count")]
        public IActionResult CountItems([FromBody] ItemRequest request)
        {
            if (request.Items == null || request.Items.Count == 0)
            {
                return BadRequest("The item list is empty or missing.");
            }

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var item in request.Items)
            {
                string key = item?.ToString()?.Trim() ?? "null";

                if (counts.ContainsKey(key))
                    counts[key]++;
                else
                    counts[key] = 1;
            }

            return Ok(counts);
        }
    }
}
