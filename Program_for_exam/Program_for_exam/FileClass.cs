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
            public void SaveDocExcel(DataGrid table)
            {

                Excel.Application app = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                var process = System.Diagnostics.Process.GetProcessesByName("EXCEL");

                SaveFileDialog openDialog = new SaveFileDialog();
                openDialog.FileName = "Чек № ";
                openDialog.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
                openDialog.FilterIndex = 2;
                openDialog.RestoreDirectory = true;

                if (openDialog.ShowDialog() == true)
                {
                    app = new Excel.Application();
                    app.DisplayAlerts = false;
                    wb = app.Workbooks.Add();
                    ws = wb.ActiveSheet;
                    table.SelectAllCells();
                    table.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    System.Windows.Input.ApplicationCommands.Copy.Execute(null, table);
                    ws.Paste();
                    ws.Range["A1", "I1"].Font.Bold = true;
                    int number1 = ws.UsedRange.Rows.Count;
                    Microsoft.Office.Interop.Excel.Range myRange = ws.Range["A1", "I" + number1];
                    myRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                    myRange.WrapText = false;
                    ws.Columns.EntireColumn.AutoFit();
                    wb.SaveAs(openDialog.FileName);
                }
            }

            public void SaveDocWord(string fileName, string text)
            {
                string pathFile = fileName;
                DocX document = DocX.Create(pathFile);
                document.InsertParagraph(text);
                document.Save();
            }

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
                Word.Application Progr = new Microsoft.Office.Interop.Word.Application();
                Progr.Documents.Open(ref fileName,
                    ref confirmConversions,
                    ref readOnly,
                    ref addToRecentFiles,
                    ref passwordDocument,
                    ref passwordTemplate,
                    ref revert,
                    ref writePasswordDocument,
                    ref writePasswordTemplate,
                    ref format,
                    ref encoding,
                    ref visible,
                    ref openConflictDocument,
                    ref openAndRepair,
                    ref documentDirection,
                    ref noEncodingDialog);
                Word.Document Doc = new Microsoft.Office.Interop.Word.Document();
                Doc = Progr.Documents.Application.ActiveDocument;
                object start = 0;
                object stop = Doc.Characters.Count;
                Word.Range Rng = Doc.Range(ref start, ref stop);
                string Result = Rng.Text;
                object sch = Type.Missing;
                object aq = Type.Missing;
                object ab = Type.Missing;
                Progr.Quit(ref sch, ref aq, ref ab);

                return Result;
            }
    }
}
