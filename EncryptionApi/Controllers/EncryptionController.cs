using Microsoft.AspNetCore.Mvc;

namespace EncryptionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        // Endpoint 1: Kryptera (Caesar-chiffer)
        [HttpGet("encrypt")]
        public IActionResult Encrypt(string text, int shift = 3)
        {
            if (string.IsNullOrEmpty(text)) return BadRequest("Text needed");

            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char letterOffset = char.IsUpper(letter) ? 'A' : 'a';
                    buffer[i] = (char)((((letter + shift) - letterOffset) % 26) + letterOffset);
                }
            }
            return Ok(new { Original = text, Encrypted = new string(buffer) });
        }

        // Endpoint 2: Avkryptera
        [HttpGet("decrypt")]
        public IActionResult Decrypt(string text, int shift = 3)
        {
            return Encrypt(text, 26 - shift);
        }
    }
}