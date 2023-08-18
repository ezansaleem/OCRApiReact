using iTextSharp.text.pdf.parser;
using System.Text;
using Tesseract;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.Text;
namespace OcrApi.Services
{
    public class TesseractOcrService
    {
        public string ExtractTextFromPdfContent(MemoryStream pdfContent)
        {
            
            StringBuilder sb = new StringBuilder();
            PdfReader reader = new PdfReader(pdfContent.ToArray());
            {

               for (int i = 1; i <= reader.NumberOfPages; i++)
               {
                        sb = sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        
               }
            }

            return sb.ToString();
        }
    }
}
