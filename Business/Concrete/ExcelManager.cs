using Business.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExcelList<T>(List<T> entity) where T : class
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells["A1"].LoadFromCollection(entity, true, OfficeOpenXml.Table.TableStyles.Dark1);
            return excelPackage.GetAsByteArray();
        }
    }
}
