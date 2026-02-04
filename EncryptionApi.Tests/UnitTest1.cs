using EncryptionApi.Controllers; // Här hämtar vi API-koden
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EncryptionApi.Tests;

public class CipherTests
{
    [Fact]
    public void Encrypt_ShouldShiftCharacters_Correctly()
    {
        // 1. Arrange
        var controller = new CipherController();
        string input = "ABC";
        int shift = 1;

        // 2. Act
        var result = controller.Encrypt(input, shift);

        // 3. Assert
        var okResult = Assert.IsType<OkObjectResult>(result);

        // NU FUNKAR DETTA: Vi berättar för testet att datan är av typen 'CipherResponse'
        var data = Assert.IsType<CipherResponse>(okResult.Value);

        Assert.Equal("BCD", data.Encrypted);
    }
}