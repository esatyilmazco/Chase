using System;
using System.Collections.Generic;
using System.IO;
using Chase.Business.Notional;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using Org.BouncyCastle.Utilities.IO;

namespace Chase.Business.Tangible
{
    public class FileManager : IFileService
    {
        public byte[] TransferExcel<T>(List<T> listEntity) where T : class, new()
        {
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add("Raporlar");
            excelBlank.Cells["A1"].LoadFromCollection(listEntity, true, OfficeOpenXml.Table.TableStyles.Light15);
            return excelPackage.GetAsByteArray();
        }
    }
}