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

namespace Program_for_exam
{
    static class ListDiscount
    {
        static public List<Tuple<string, int>> listDiscount = new List<Tuple<string, int>>();

    }

    public class File
    {
        private Excel.Workbook TableToExcel(DataGrid table)
        {
            Excel.Application excel = new Excel.Application();
            //excel.Visible = false;
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet = (Excel.Worksheet)excel.Worksheets.get_Item(1);

            for (int j = 0; j < table.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet.Cells[1, j + 1];
                sheet.Cells[1, j + 1].Font.Bold = true;
                myRange.Value2 = table.Columns[j].Header;
            }

            for (int i = 0; i < table.Columns.Count; i++)
            {
                for (int j = 0; j < table.Items.Count; j++)
                {
                    TextBlock b = table.Columns[i].GetCellContent(table.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = 
                        (Microsoft.Office.Interop.Excel.Range)sheet.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
            return workbook;
        }

        public void SaveDocExcel(DataGrid table)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            Excel.Workbook workbook = TableToExcel(table);

            saveFileDialog1.Filter = "Excel documents (*.xlsx)|*.xlsx";
            saveFileDialog1.RestoreDirectory = true;

            if (table.Items.Count != 0)
            {
                if (saveFileDialog1.ShowDialog() == true)
                {
                    string fileName = saveFileDialog1.FileName;
                    workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //sheet1 = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                }
            }
            else
                if (MessageBox.Show("Вы действительно хотите сохранить таблицу в файл?", 
                    "В таблице нет записей",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == true)
                    {
                        string fileName = saveFileDialog1.FileName;
                        workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
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

    public class Connection
    {
        protected MySqlConnection _connection;

        protected Connection(string option)
        {
            _connection = new MySqlConnection(option);
            _connection.Open();
        }

        ~Connection()
        {
            _connection.Close();
        }
    }

    public class Item
    {
        public string numberSale { get; set; }
        public string nameWorker { get; set; }
        public string positionWorker { get; set; }
        public string nameTechnic { get; set; }
        public string typeTechnic { get; set; }
        public string priceTechnic { get; set; }
        public string dataFabricator { get; set; }
        public string date { get; set; }
        public string status { get; set; }
    }

    public class ItemWorker
    {
        public string nameWorker { get; set; }
        public string positionWorker { get; set; }
    }

    public class ItemProduct
    {
        public string nameProduct { get; set; }
        public string typeProduct { get; set; }
        public string nameFabricator { get; set; }
        public string priceProduct { get; set; }
    }

    public class Discount
    {
        public string product { get; set; }
        public string discount { get; set; }
    }

    interface IDataBase
    {
        void OutputTable(DataGrid DG, int choose);

        void CreateNewSale(string firstName, string secondName,
            string middleName, string position,
            string product, System.Windows.Controls.TextBox country = null,
            System.Windows.Controls.TextBox city = null, System.Windows.Controls.TextBox street = null);

        bool DeleteSale(string numberSale);

        void GetStaff(ComboBox comboBox);
    }

    public class DataBase : Connection, IDataBase
    {
        public DataBase(string option) : base(option) { }

        public void OutputTableStaff(DataGrid DG)
        {
            DG.Items.Clear();

            string sql = "SELECT second_name,first_name,middle_name,position FROM `staff`";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString() + " " + 
                    reader[1].ToString() + " " + reader[2].ToString();
                data[data.Count - 1][1] = reader[3].ToString();
            }
            
            foreach(string[] s in data)
            {
                DG.Items.Add(new ItemWorker()
                {
                    nameWorker = s[0],
                    positionWorker = s[1]
                }) ;
            }

            reader.Close();
        }

        public void OutputAllTechnic(ComboBox comboBox)
        {
            string sql = "SELECT t.name, t.type, f.name FROM `technic` t " +
                "LEFT OUTER JOIN `fabricators` f ON f.id = t.fabricator_id";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                comboBox.Items.Add("Название: " + reader[0] + "; Тип: " + reader[1] + "; " +
                    "Кем произведён: " + reader[2]);
            }

            reader.Close();
        }

        public void OutputAllDiscount(ComboBox comboBox)
        {
            string sql = "SELECT * FROM `discount`";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                comboBox.Items.Add(reader[0].ToString());
            }
            reader.Close();
        }

        public void OutputProduct(ComboBox comboBox)
        {
            string sql = "SELECT t.name, t.type, f.name, t.price FROM `technic` t " +
                "LEFT OUTER JOIN `fabricators` f ON f.id = t.fabricator_id";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                comboBox.Items.Add("Название: " + reader[0].ToString() + "; Тип: " + reader[1].ToString() + 
                    "; Название производителя: " + reader[2].ToString() + "; Цена: " + reader[3].ToString());
            }
            reader.Close();
        }

        public void OutputTableTechnic(DataGrid dataGrid)
        {
            dataGrid.Items.Clear();

            string sql = "SELECT t.name,t.type,f.name,t.price FROM `technic` t " +
                "LEFT OUTER JOIN `fabricators` f ON f.id = t.fabricator_id";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }

            foreach (string[] s in data)
            {
                dataGrid.Items.Add(new ItemProduct()
                {
                    nameProduct = s[0],
                    typeProduct = s[1],
                    nameFabricator = s[2],
                    priceProduct = s[3],
                });
            }

                reader.Close();
        }

        public void OutputTable(DataGrid DG, int choose = 0)
        {
            DG.Items.Clear();

            string sql = string.Empty;
            
            switch (choose)
            {
                case 0:
                    sql = "SELECT s.id, w.second_name, w.first_name, w.middle_name, w.position, f.name, " +
                "t.name, t.type, s.price, s.date, s.address_id FROM `sale` s " +
                "LEFT OUTER JOIN `staff` w ON w.id = s.worker_id " +
                "LEFT OUTER JOIN `technic` t ON t.id = s.technic_id " +
                "LEFT OUTER JOIN `fabricators` f ON f.id = t.fabricator_id";
                    break;

                case 1:
                    sql = "SELECT s.id, w.second_name, w.first_name, w.middle_name, w.position, f.name, " +
                "t.name, t.type, s.price, s.date, s.address_id FROM `sale` s " +
                "LEFT OUTER JOIN `staff` w ON w.id = s.worker_id " +
                "LEFT OUTER JOIN `technic` t ON t.id = s.technic_id " +
                "LEFT OUTER JOIN `fabricators` f ON f.id = t.fabricator_id " +
                "WHERE s.address_id <=> NULL";
                    break;

                case 2:
                    sql = "SELECT s.id, w.second_name, w.first_name, w.middle_name, w.position, f.name, " +
                "t.name, t.type, s.price, s.date, s.address_id FROM `sale` s " +
                "LEFT OUTER JOIN `staff` w ON w.id = s.worker_id " +
                "LEFT OUTER JOIN `technic` t ON t.id = s.technic_id " +
                "LEFT OUTER JOIN `fabricators` f ON f.id = t.fabricator_id " +
                "WHERE s.address_id IS NOT NULL";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[9]);

                data[data.Count - 1][0] = reader[0].ToString();

                data[data.Count - 1][1] = reader[1].ToString() + " " +
                    reader[2].ToString() + " " + reader[3].ToString();

                data[data.Count - 1][2] = reader[4].ToString();
                data[data.Count - 1][3] = reader[5].ToString();
                data[data.Count - 1][4] = reader[6].ToString();
                data[data.Count - 1][5] = reader[7].ToString();
                data[data.Count - 1][6] = reader[8].ToString();
                data[data.Count - 1][7] = reader[9].ToString().Substring(0,10);

                if (reader[10].ToString() == "")
                    data[data.Count - 1][8] = "получено";
                else
                    data[data.Count - 1][8] = "доставляется";
            }

            reader.Close();

            foreach (string[] s in data)
            {
                DG.Items.Add(new Item()
                {
                    numberSale = s[0],
                    nameWorker = s[1],
                    positionWorker = s[2],
                    dataFabricator = s[3],
                    nameTechnic = s[4],
                    typeTechnic = s[5],
                    priceTechnic = s[6],
                    date = s[7],
                    status = s[8]
                });
            }
        }

        public bool CheckFullStaff(System.Windows.Controls.TextBox secondName, System.Windows.Controls.TextBox firstName, 
            System.Windows.Controls.TextBox middleName, string position)
        {
            object result = new object();

            string sql = "SELECT id FROM staff WHERE second_name = '" + secondName.Text + "' AND " +
                "first_name = '" + firstName.Text + "' AND middle_name = '" + middleName.Text + "' " +
                "AND position = '" + position + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private bool CheckFullFabricator(System.Windows.Controls.TextBox name)
        {
            string sql = "SELECT id FROM fabricators WHERE name = '" + name.Text + "'";

            object result = new object();

            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private bool CheckFullTechnic(System.Windows.Controls.TextBox nameTechnic, System.Windows.Controls.TextBox typeTechnic,
            System.Windows.Controls.TextBox nameFabricator, System.Windows.Controls.TextBox price)
        {
            string sql = string.Empty;
            MySqlCommand command;

            if (CheckFullFabricator(nameFabricator))
            {
                object result = new object();

                sql = "SELECT id FROM technic WHERE fabricator_id = (SELECT id FROM fabricators " +
                    "WHERE name = '" + nameFabricator.Text + "') AND name = '" + nameTechnic.Text + "' " +
                    "AND type = '" + typeTechnic.Text + "' AND price = " + price.Text;

                command = new MySqlCommand(sql, _connection);
                result = command.ExecuteScalar();

                if (result == null)
                    return false;
                else
                    return true;
            }
            else
            {
                sql = "INSERT INTO `fabricators`(`id`,`name`) VALUES (NULL,'" + nameFabricator.Text + "')";

                command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();

                return false;
            }
        }

        private bool CheckFullAddress(System.Windows.Controls.TextBox country, System.Windows.Controls.TextBox city, 
            System.Windows.Controls.TextBox street)
        {
            string sql = "SELECT id FROM address WHERE country = '" + country.Text + "' " +
                "AND city = '" + city.Text + "' AND street = '" + street.Text + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private void CreateNewAddress(System.Windows.Controls.TextBox country, System.Windows.Controls.TextBox city,
            System.Windows.Controls.TextBox street)
        {
            string sql = "INSERT INTO `address`(`id`,`country`,`city`,`street`) VALUES " +
                "(NULL,'" + country.Text + "','" + city.Text + "','" + street.Text + "')";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        public bool CreateNewTechnic(System.Windows.Controls.TextBox name, System.Windows.Controls.TextBox type,
            System.Windows.Controls.TextBox price, System.Windows.Controls.TextBox nameFabricator)
        {
            if (CheckFullTechnic(name,type, nameFabricator,price))
            {
                return false;
            }
            else
            {
                string sql = "INSERT INTO `technic`(`id`,`fabricator_id`,`name`,`type`,`price`) VALUES " +
                    "(NULL, (SELECT id FROM fabricators WHERE name = '" + nameFabricator.Text + "'), '" + name.Text + "'," +
                    "'" + type.Text + "', " + price.Text + ")";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();
                return true;
            }
        }

        public void CreateNewWorker(System.Windows.Controls.TextBox secondName, System.Windows.Controls.TextBox firstName,
            System.Windows.Controls.TextBox middleName, string position)
        {
            string sql = "INSERT INTO `staff`(`id`,`second_name`,`first_name`,`middle_name`,`position`) " +
                "VALUES (NULL, '" + secondName.Text + "', '" + firstName.Text + "', '" + middleName.Text + "', " +
                "'" + position + "')";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        private (string,string,string,string) GetProductInfo(string product)
        {
            string name = ""; string type = ""; string nameFabricator = ""; string price = "";

            string word = "";

            for (int i = 0; i < product.Length; i++)
            {
                if(product[i]==';')
                    word = "";
                else 
                {
                    switch (word)
                    {
                        case "Название: ":
                            name += product[i];
                            break;

                        case " Тип: ":
                            type += product[i];
                            break;

                        case " Название производителя: ":
                            nameFabricator += product[i];
                            break;

                        case " Цена: ":
                            price += product[i];
                            break;

                        default:
                            word += product[i];
                            break;
                    }
                }
                    
            }

            return (name, type, nameFabricator, price);
        }

        public void CreateNewSale(string firstName, string secondName, string middleName, string position,
            string product, System.Windows.Controls.TextBox country = null,
            System.Windows.Controls.TextBox city = null, System.Windows.Controls.TextBox street = null)
        {
            bool nonNull = (country!= null) && (city != null) && (street != null);

            string sql = string.Empty;

            DateTime date = DateTime.Now;
            string dateForMySql = date.ToString("yyyy-MM-dd");

            var tuple = GetProductInfo(product);

            string productForDiscount = "Название: " + tuple.Item1 + 
                "; Тип: " + tuple.Item2 + "; Кем произведён: " + tuple.Item3; 

            if (nonNull)
            {
                bool fullAddress = CheckFullAddress(country, city, street);

                if (!fullAddress)
                    CreateNewAddress(country, city, street);
                    
                sql = "INSERT INTO `sale`(`id`,`worker_id`,`technic_id`,`date`,`address_id`,`price`) VALUES " +
                "(NULL,(SELECT id FROM staff WHERE second_name = '" + secondName + "' AND " +
                "first_name = '" + firstName + "' AND middle_name = '" + middleName + "' " +
                "AND position = '" + position + "'),(SELECT id FROM technic WHERE fabricator_id =(SELECT id FROM fabricators " +
                "WHERE name = '" + tuple.Item3 + "') AND name = '" + tuple.Item1 + "' AND type = '" + tuple.Item2 + "' " +
                "AND price = " + tuple.Item4 + "),'" + dateForMySql + "',(SELECT id FROM address WHERE country = '" + country.Text + "' " +
                "AND city = '" + city.Text + "' AND street = '" + street.Text + "'),"+ tuple.Item4 + "-" + tuple.Item4 + "*0.01*" +
                "(SELECT IF((SELECT COUNT(*) FROM `discount` WHERE product ='"+productForDiscount +"')=0,0,(SELECT discount FROM `discount`WHERE product = '"+productForDiscount +"'))))";
            }
            else
            {
                sql = "INSERT INTO `sale`(`id`,`worker_id`,`technic_id`,`date`,`address_id`,`price`) VALUES " +
                "(NULL,(SELECT id FROM staff WHERE second_name = '" + secondName + "' AND " +
                "first_name = '" + firstName + "' AND middle_name = '" + middleName + "' " +
                "AND position = '" + position + "'),(SELECT id FROM technic WHERE fabricator_id =(SELECT id FROM fabricators " +
                "WHERE name = '" + tuple.Item3 + "') AND name = '" + tuple.Item1 + "' AND type = '" + tuple.Item2 + "' " +
                "AND price = " + tuple.Item4 + "),'" + dateForMySql + "',NULL," + tuple.Item4 + "-" + tuple.Item4 + "*0.01*" +
                "(SELECT IF((SELECT COUNT(*) FROM `discount` WHERE product ='" + productForDiscount + "')=0,0,(SELECT discount FROM `discount` WHERE product = '" + productForDiscount + "'))))";
            }

            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        public bool DeleteSale(string numberSale)
        {
            string sql = "DELETE FROM `sale` WHERE id = '" + numberSale + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            int number = command.ExecuteNonQuery();

            if (number >= 1)
            {
                if (Convert.ToInt32(numberSale) == Convert.ToInt32(GetLastSaleNumber())+1)
                {
                    sql = "ALTER TABLE `sale` AUTO_INCREMENT = " + GetLastSaleNumber();
                    command = new MySqlCommand(sql, _connection);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            else
                return false;
        }

        private (string, string) SaleInformation(string text)
        {
            string date = string.Empty;
            string number = string.Empty;

            char[] separator = { ' ', '\v', '\r' };
            string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 2; i < words.Length; i++)
            {
                if (words[i - 2] == "Номер" && words[i - 1] == "покупки:")
                    number = words[i];

                if (words[i - 2] == "Дата" && words[i - 1] == "покупки:")
                    date = words[i];
            }

            return (number, date);
        }

        public bool IssueRefund(string text, ref string number)
        {
            string date;

            var Tuple = SaleInformation(text);

            number = Tuple.Item1;
            date = Tuple.Item2;

            try
            {
                string sql = "SELECT date FROM `sale` WHERE id = " + number;

                MySqlCommand command = new MySqlCommand(sql, _connection);
                string dateSale = command.ExecuteScalar().ToString();

                DateTime currentDate = DateTime.Now;
                string dateForMySql = currentDate.ToString("dd.MM.yyyy");

                bool check = true;
                for (int i = 0; i < 10; i++)
                {
                    if (dateSale[i] != dateForMySql[i])
                        check = false;
                }

                if (check)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public string GetLastSaleNumber()
        {
            string number = string.Empty;

            string sql = "SELECT MAX(id) FROM `sale`";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            number = command.ExecuteScalar().ToString();

            return number;
        }

        public void GetStaff(ComboBox comboBox)
        {
            string sql = "SELECT second_name,first_name,middle_name,position " +
                "FROM `staff`";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox.Items.Add(reader[0] + " " + reader[1] + " " + reader[2]
                    + " " + reader[3]);
            }
            reader.Close();
        }

        public bool UpdateSale(string numberSale)
        {
            string sql = "UPDATE `sale` SET address_id = NULL WHERE id = " + numberSale + " AND address_id IS NOT NULL";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            int number = command.ExecuteNonQuery();

            if (number >= 1)
                return true;
            else
                return false;
        }

        public void OutputTableDiscount(DataGrid dataGrid)
        {
            string sql = "SELECT * FROM `discount`";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }

            foreach (string[] s in data)
            {
                dataGrid.Items.Add(new Discount()
                {
                    product = s[0],
                    discount = s[1],
                });
            }
            reader.Close();
        }

        public void DeleteDiscount(string product="delete all")
        {
            string sql = string.Empty;

            if (product != "delete all")
                sql = "DELETE FROM `discount` WHERE product = '" + product + "'";

            else
                sql = "DELETE FROM `discount`";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        private bool CheckDiscount(string product)
        {
            string sql = "SELECT COUNT(*) FROM `discount` WHERE product = '" + product + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            object count = command.ExecuteScalar();

            if (Convert.ToInt32(count) == 0)
                return true;
            else
                return false;
        }

        public bool AddDiscount(string product, string discount)
        {
            if (!CheckDiscount(product))
                return false;
            else
            {
                string sql = "INSERT INTO `discount`(`product`,`discount`) VALUES " +
                    "('" + product + "'," + discount + ")";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();

                return true;
            }
        }

        public void UpdateDiscount(string product, string discount)
        {
            string sql = "UPDATE `discount` SET discount = " + discount + " WHERE " +
                "product = '" + product + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
    }
}
