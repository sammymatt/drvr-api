using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DrvrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private string filePath = "C:\\Users\\User\\source\\repos\\DrvrApi\\DrvrApi\\Controllers\\scores.txt";


        [HttpGet("GetScores")]
        public async Task<IActionResult> GetScores()
        {
            try
            {
                string content = await System.IO.File.ReadAllTextAsync(filePath);
                return Ok(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddScore")]
        public async Task<IActionResult> AddScore([FromBody] string score)
        {
            try
            {
                if (string.IsNullOrEmpty(score))
                {
                    return BadRequest("Score cannot be null or empty.");
                }

                await System.IO.File.AppendAllTextAsync(filePath, score + Environment.NewLine);

                return Ok("Score added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
