using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OcrApi.Services;
using System.IO;
using System.Threading.Tasks;

namespace OcrApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcrController : ControllerBase
    {
        private readonly TesseractOcrService _ocrService;

        public OcrController(TesseractOcrService ocrService)
        {
            _ocrService = ocrService;
        }

        [HttpPost("extract-text")]
        public async Task<IActionResult> ExtractTextFromPdf([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            
            var extractedText = _ocrService.ExtractTextFromPdfContent(memoryStream);
            return Ok(new { ExtractedText = extractedText });
        }
    }
}
