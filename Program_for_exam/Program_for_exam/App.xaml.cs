using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using Xceed.Words.NET;
using Xceed.Document.NET;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Windows.Markup;
using System.Runtime.CompilerServices;

namespace Program_for_exam
{
   
    static class ListDiscount
    {
        static public List<Tuple<string, int>> listDiscount = new List<Tuple<string, int>>();
    }

    static class DataBaseOption
    {
        static private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        static public string dataBaseOption => _dataBaseOption;
    }

    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
    }
}
