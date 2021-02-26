using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Threading;

namespace OlanAuctions.ExcelData
{
    class ExcelFile
    {
        private Application excelFile;
        private Workbook workbook;
        private Worksheet worksheet;

        public ExcelFile(int sheetIndex = 1, string fileName = "OlanAuctionsTest.xlsx")
        {
            var filePath = $@"{Directory.GetCurrentDirectory()}\ExcelData\{fileName}";
            excelFile = new Application();
            workbook = excelFile.Workbooks.Open(filePath);
            worksheet = workbook.Worksheets[sheetIndex];
        }

        /*
         * Description: Gets the value of a specified key in the excel file cell. By default, in the constructor, it gets the first sheet
         *              unless the user specifies another sheet index.
         *@params : test case ID, key, desired column index
         *@returns : the value of the key.
         *
         *e.g. username=josh;
         *key is username
         *string 'josh' is returned.
         */
        public string GetDataWithKey(int testcaseId, string key, int col = 4)
        {
            string value = "";
            char[] testDataSeparator = { ';', '\n' };
            var cellValue = GetCellValue(testcaseId + 1, col);
            string[] vals = cellValue.Split(testDataSeparator);
            char[] keyValueSeparator = { '=' };
            foreach (string data in vals)
            {
                string[] keyValue = data.Split(keyValueSeparator);
                TextInfo txt = new CultureInfo("en-UK",false).TextInfo;
                if (txt.ToTitleCase(keyValue[0]) == txt.ToTitleCase(key))
                {
                    value = keyValue[1];
                    break;
                }
            }
            return value;
        }

        private string GetCellValue(int row, int col)
        {
            string cellValue = "";
            if (worksheet.Cells[row, col].Value2 != null)
                cellValue = worksheet.Cells[row, col].Value2.ToString();
            return cellValue;
        }

        public void CloseWorkBook()
        {
            workbook.Close(0);
            excelFile.Quit();
            Marshal.ReleaseComObject(excelFile);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(worksheet);
            excelFile = null;
        }
    }
}
