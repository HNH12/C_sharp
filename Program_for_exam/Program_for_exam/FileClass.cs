using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.Windows.Controls;
using System.IO;
using Xceed.Words.NET;
using Xceed.Document.NET;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Markup;
using System.Runtime.CompilerServices;

namespace Program_for_exam
{
    class FileClass
    {
            /// <summary>
            /// Сохраняет указанную таблицу в файл excel;
            /// </summary>
            /// <param name="table"></param>
            public void SaveDocExcel(DataGrid table)
            {

                Excel.Application application = null;
                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;
                var process = System.Diagnostics.Process.GetProcessesByName("EXCEL");

                string date = DateTime.Now.ToString("yyyy-MM-dd");

                SaveFileDialog openDialog = new SaveFileDialog();
                openDialog.FileName = String.Format("Таблица продаж от {0}", date);
                openDialog.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
                openDialog.FilterIndex = 2;
                openDialog.RestoreDirectory = true;

                if (openDialog.ShowDialog() == true)
                {
                    application = new Excel.Application();
                    application.DisplayAlerts = false;

                    workbook = application.Workbooks.Add();
                    worksheet = workbook.ActiveSheet;

                    table.SelectAllCells();
                    table.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    System.Windows.Input.ApplicationCommands.Copy.Execute(null, table);

                    worksheet.Paste();
                    worksheet.Range["A1", "I1"].Font.Bold = true;
                    int number1 = worksheet.UsedRange.Rows.Count;
                    Microsoft.Office.Interop.Excel.Range myRange = worksheet.Range["A1", "I" + number1];

                    myRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                    myRange.WrapText = false;

                    worksheet.Columns.EntireColumn.AutoFit();
                    workbook.SaveAs(openDialog.FileName);
                }
            }

            /// <summary>
            /// Сохраняет текст в файл word;
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="text"></param>
            public void SaveDocWord(string fileName, string text)
            {
                string pathFile = fileName;
                DocX document = DocX.Create(pathFile);

                document.InsertParagraph(text);
                document.Save();
            }

            /// <summary>
            /// Считывает текст с файла word;
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns></returns>
            public string GetTextDocWord(Object fileName)
            {
                Object confirmConversions = Type.Missing;
                Object readOnly = Type.Missing;
                Object addToRecentFiles = Type.Missing;
                Object passwordDocument = Type.Missing;
                Object passwordTemplate = Type.Missing;
                Object revert = Type.Missing;
                Object writePasswordDocument = Type.Missing;
                Object writePasswordTemplate = Type.Missing;
                Object format = Type.Missing;
                Object encoding = Type.Missing;
                Object visible = Type.Missing;
                Object openConflictDocument = Type.Missing;
                Object openAndRepair = Type.Missing;
                Object documentDirection = Type.Missing;
                Object noEncodingDialog = Type.Missing;

                Word.Application program = new Microsoft.Office.Interop.Word.Application();
                program.Documents.Open(ref fileName, ref confirmConversions, ref readOnly, ref addToRecentFiles, ref passwordDocument,
                    ref passwordTemplate, ref revert, ref writePasswordDocument, ref writePasswordTemplate, ref format, ref encoding,
                    ref visible, ref openConflictDocument, ref openAndRepair, ref documentDirection, ref noEncodingDialog);

                Word.Document document = new Microsoft.Office.Interop.Word.Document();
                document = program.Documents.Application.ActiveDocument;

                object start = 0;
                object stop = document.Characters.Count;

                Word.Range range = document.Range(ref start, ref stop);

                string result = range.Text;
                object saveChanges = Type.Missing;
                object originalFormat = Type.Missing;
                object routeDocument = Type.Missing;
                program.Quit(ref saveChanges, ref originalFormat, ref routeDocument);

                return result;
            }
    }
}
