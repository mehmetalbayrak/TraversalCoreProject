using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/dosya1.pdf","application/pdf","dosya1.pdf");
        }
        public IActionResult CustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdPfTable = new PdfPTable(3);
            pdPfTable.AddCell("Misafir Adı");
            pdPfTable.AddCell("Misafir Soyadı");
            pdPfTable.AddCell("Misafir TC");
            document.Add(pdPfTable);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
    }
}
