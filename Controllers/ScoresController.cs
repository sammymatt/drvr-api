using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DrvrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {

        [HttpGet("GetScores")]
        public async Task<IActionResult> GetScores()
        {
            try
            {
                string filePath = "C:\\Users\\User\\source\\repos\\DrvrApi\\DrvrApi\\Controllers\\scores.txt";
                string content = await System.IO.File.ReadAllTextAsync(filePath);
                return Ok(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error"); 
            }
        }
    }
}
