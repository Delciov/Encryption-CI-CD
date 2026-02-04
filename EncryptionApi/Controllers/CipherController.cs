using Microsoft.AspNetCore.Mvc;

namespace EncryptionApi.Controllers
{
    // Vi definierar hur svaret ser ut så att testet kan läsa det
    public class CipherResponse
    {
        public string? Original { get; set; }
        public string? Encrypted { get; set; }
        public string? Decrypted { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class CipherController : ControllerBase
    {
        [HttpGet("encrypt")]
        public IActionResult Encrypt(string text, int shift)
        {
            if (string.IsNullOrEmpty(text)) return BadRequest("Text cannot be empty");

            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                buffer[i] = (char)(letter + shift);
            }

            // HÄR ÄR ÄNDRINGEN: Vi returnerar en riktig klass istället för anonym
            return Ok(new CipherResponse
            {
                Original = text,
                Encrypted = new string(buffer)
            });
        }

        [HttpGet("decrypt")]
        public IActionResult Decrypt(string text, int shift)
        {
            if (string.IsNullOrEmpty(text)) return BadRequest("Text cannot be empty");

            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                buffer[i] = (char)(letter - shift);
            }

            return Ok(new CipherResponse
            {
                Encrypted = text,
                Decrypted = new string(buffer)
            });
        }
    }
}