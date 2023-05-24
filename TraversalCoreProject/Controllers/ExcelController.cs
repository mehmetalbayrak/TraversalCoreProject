using Business.Abstract;
using ClosedXML.Excel;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public List<DestinationViewModel> DestinationList()
        {
            List<DestinationViewModel> destinationViewModels = new List<DestinationViewModel>();
            using (var context = new Context())
            {
                destinationViewModels = context.Destinations.Select(x => new DestinationViewModel
                {
                    City = x.City,
                    Capacity = x.Capacity,
                    Price = x.Price,
                    DayNight = x.DayNight
                }).ToList();
            }
            return destinationViewModels;
        }
        public IActionResult StaticExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
        }
        public IActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tur Listesi");
                worksheet.Cell(1, 1).Value = "Şehir";
                worksheet.Cell(1, 2).Value = "Konaklama Süresi";
                worksheet.Cell(1, 3).Value = "Fiyat";
                worksheet.Cell(1, 4).Value = "Kapasite";
                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.City;
                    worksheet.Cell(rowCount, 2).Value = item.DayNight;
                    worksheet.Cell(rowCount, 3).Value = item.Price;
                    worksheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}
