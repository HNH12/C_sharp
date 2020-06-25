using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.Windows.Controls;

namespace Program_for_exam
{
    class DataBaseClass
    {
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
            public string priceSale { get; set; }
            public string nameFabricator { get; set; }
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
            void OutputTable(DataGrid dataGrid, int choose);

            void CreateNewSale(string firstName, string secondName,
                string middleName, string position,
                string product, string country = null,
                string city = null, string street = null);

            bool DeleteSale(string numberSale);

            List<string> GetStaff();
        }

        public class DataBase : Connection
        {
            public DataBase(string option) : base(option) { }

            /// <summary>
            /// Выводит информацию в указанный DataGrid;
            /// </summary>
            /// <param name="dataGrid"></param>
            /// <param name="choose"></param>
            public void OutputTable(DataGrid dataGrid, int choose = 0)
            {
                dataGrid.Items.Clear();

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
                    data[data.Count - 1][7] = reader[9].ToString().Substring(0, 10);

                    if (reader[10].ToString() == "")
                        data[data.Count - 1][8] = "получено";
                    else
                        data[data.Count - 1][8] = "доставляется";
                }
                reader.Close();

                foreach (string[] s in data)
                {
                    dataGrid.Items.Add(new Item()
                    {
                        numberSale = s[0],
                        nameWorker = s[1],
                        positionWorker = s[2],
                        nameFabricator = s[3],
                        nameTechnic = s[4],
                        typeTechnic = s[5],
                        priceSale = s[6],
                        date = s[7],
                        status = s[8]
                    });
                }
            }

            /// <summary>
            /// Проверка на существование в базе данных указанного адреса;
            /// </summary>
            /// <param name="country"></param>
            /// <param name="city"></param>
            /// <param name="street"></param>
            /// <returns></returns>
            private bool CheckFullAddress(string country, string city, string street)
            {
                string sql = String.Format("SELECT id FROM address WHERE country = '{0}' AND city = '{1}' AND street = '{2}'",
                    country, city, street);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                object result = command.ExecuteScalar();

                if (result == null)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }

            /// <summary>
            /// Добавляет в базу данных новый адрес;
            /// </summary>
            /// <param name="country"></param>
            /// <param name="city"></param>
            /// <param name="street"></param>
            private void CreateNewAddress(string country, string city, string street)
            {
                string sql = String.Format("INSERT INTO `address`(`id`,`country`,`city`,`street`) VALUES (NULL, '{0}', '{1}', '{2}')",
                    country, city, street);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();
            }

            /// <summary>
            /// Добавляет в базу данных новую продажу;
            /// </summary>
            /// <param name="firstName"></param>
            /// <param name="secondName"></param>
            /// <param name="middleName"></param>
            /// <param name="position"></param>
            /// <param name="product"></param>
            /// <param name="country"></param>
            /// <param name="city"></param>
            /// <param name="street"></param>
            public void CreateNewSale(string firstName, string secondName, string middleName, string position,
                string product, string country = null, string city = null, string street = null)
            {
                bool withDelivery = (country != null) && (city != null) && (street != null);

                string sql = string.Empty;

                DateTime date = DateTime.Now;
                string dateForMySql = date.ToString("yyyy-MM-dd");

                var tuple = GetProductInfo(product);

                string checkingProductDiscount = String.Format("Название: {0}; Тип: {1}; Кем произведён: {2}",
                    tuple.Item1, tuple.Item2, tuple.Item3);

                if (withDelivery)
                {
                    bool fullAddress = CheckFullAddress(country, city, street);

                    if (!fullAddress)
                    {
                        CreateNewAddress(country, city, street);
                    }

                    sql = String.Format("INSERT INTO `sale`(`id`,`worker_id`,`technic_id`,`date`,`address_id`,`price`) " +
                    "VALUES (NULL,(SELECT id FROM staff WHERE second_name = '{0}' AND first_name = '{1}' AND middle_name = '{2}' AND position = '{3}')," +
                    "(SELECT id FROM technic WHERE fabricator_id =(SELECT id FROM fabricators WHERE name = '{4}') AND name = '{5}' AND type = '{6}' " +
                    "AND price = {7}),'{8}',(SELECT id FROM address WHERE country = '{9}' AND city = '{10}' AND street = '{11}')," +
                    "{7}-{7}*0.01*(SELECT IF((SELECT COUNT(*) FROM `discount` WHERE product ='{12}')=0,0,(SELECT discount FROM `discount`WHERE product = '{12}'))))",
                    secondName, firstName, middleName, position, tuple.Item3, tuple.Item1, tuple.Item2, tuple.Item4, dateForMySql, country, city,
                    street, checkingProductDiscount);
                }
                else
                {
                    sql = String.Format("INSERT INTO `sale`(`id`,`worker_id`,`technic_id`,`date`,`address_id`,`price`) VALUES " +
                    "(NULL,(SELECT id FROM staff WHERE second_name = '{0}' AND first_name = '{1}' AND middle_name = '{2}' AND position = '{3}')," +
                    "(SELECT id FROM technic WHERE fabricator_id =(SELECT id FROM fabricators WHERE name = '{4}') AND name = '{5}' AND type = '{6}' AND price = {7})," +
                    "'{8}',NULL,{7}-{7}*0.01*(SELECT IF((SELECT COUNT(*) FROM `discount` WHERE product ='{9}')=0,0,(SELECT discount FROM `discount` WHERE product = '{9}'))))",
                    secondName, firstName, middleName, position, tuple.Item3, tuple.Item1, tuple.Item2, tuple.Item4, dateForMySql, checkingProductDiscount);
                }

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();
            }

            /// <summary>
            /// Удаляет из базы данных продажу с указанным номером;
            /// </summary>
            /// <param name="numberSale"></param>
            /// <returns></returns>
            public bool DeleteSale(string numberSale)
            {
                string sql = String.Format("DELETE FROM `sale` WHERE id = '{0}'", numberSale);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                int number = command.ExecuteNonQuery();

                if (number >= 1)
                {
                    if (Convert.ToInt32(numberSale) == Convert.ToInt32(GetLastSaleNumber()) + 1)
                    {
                        sql = "ALTER TABLE `sale` AUTO_INCREMENT = " + GetLastSaleNumber();
                        command = new MySqlCommand(sql, _connection);
                        command.ExecuteNonQuery();
                    }
                    return true;
                }

                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Преобразование данных о продаже к двум переменным типа string;
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private (string, string) SaleInformation(string text)
            {
                string date = string.Empty;
                string saleNumber = string.Empty;

                char[] separator = { ' ', '\v', '\r' };
                string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 2; i < words.Length; i++)
                {
                    if (words[i - 2] == "Номер" && words[i - 1] == "покупки:")
                    {
                        saleNumber = words[i];
                    }

                    if (words[i - 2] == "Дата" && words[i - 1] == "покупки:")
                    {
                        date = words[i];
                    }
                }

                return (saleNumber, date);
            }

            /// <summary>
            /// Преобразование данных о товаре к четырём переменных типа string;
            /// </summary>
            /// <param name="product"></param>
            /// <returns></returns>
            private (string, string, string, string) GetProductInfo(string product)
            {
                string name = ""; string type = ""; string nameFabricator = "";
                string price = ""; string currentWord = "";

                for (int i = 0; i < product.Length; i++)
                {
                    if (product[i] == ';')
                    {
                        currentWord = "";
                    }
                    else
                    {
                        switch (currentWord)
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
                                currentWord += product[i];
                                break;
                        }
                    }

                }

                return (name, type, nameFabricator, price);
            }

            /// <summary>
            /// Проверяет, можно ли оформить возврат указанной покупки;
            /// </summary>
            /// <param name="text"></param>
            /// <param name="saleNumber"></param>
            /// <returns></returns>
            public bool IssueRefund(string text, ref string saleNumber)
            {
                string date;

                var Tuple = SaleInformation(text);

                saleNumber = Tuple.Item1;
                date = Tuple.Item2;

                try
                {
                    string sql = String.Format("SELECT date FROM `sale` WHERE id = {0}", saleNumber);

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

            /// <summary>
            /// Возвращает номер последней продажи;
            /// </summary>
            /// <returns></returns>
            public string GetLastSaleNumber()
            {
                string number = string.Empty;

                string sql = "SELECT MAX(id) FROM `sale`";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                number = command.ExecuteScalar().ToString();

                return number;
            }

            /// <summary>
            /// Изменяет статус указанной продажи;
            /// </summary>
            /// <param name="saleNumber"></param>
            /// <returns></returns>
            public bool UpdateSaleStatus(string saleNumber)
            {
                string sql = String.Format("UPDATE `sale` SET address_id = NULL WHERE id = {0} AND address_id IS NOT NULL", saleNumber);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                int number = command.ExecuteNonQuery();

                if (number >= 1)
                    return true;
                else
                    return false;
            }

            /// <summary>
            /// Выводит информацию о товарах в указанный DataGrid;
            /// </summary>
            /// <param name="dataGrid"></param>
            public void OutputTableProduct(DataGrid dataGrid)
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
                reader.Close();

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
            }

            /// <summary>
            /// Проверка на существование в базе данных производителя с указанными данными;
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            private bool CheckFullFabricator(string name)
            {
                string sql = String.Format("SELECT id FROM fabricators WHERE name = '{0}'", name);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                object result = command.ExecuteScalar();

                if (result == null)
                    return false;
                else
                    return true;
            }

            /// <summary>
            /// Проверка на существование в базе данных техники с указанными данными;
            /// </summary>
            /// <param name="nameTechnic"></param>
            /// <param name="typeTechnic"></param>
            /// <param name="nameFabricator"></param>
            /// <param name="price"></param>
            /// <returns></returns>
            private bool CheckFullTechnic(string nameTechnic, string typeTechnic, string nameFabricator, string price)
            {
                string sql = string.Empty;
                MySqlCommand command;

                if (CheckFullFabricator(nameFabricator))
                {
                    sql = String.Format("SELECT id FROM technic WHERE fabricator_id = (SELECT id FROM fabricators " +
                        "WHERE name = '{0}') AND name = '{1}' AND type = '{2}' AND price = {3}",
                        nameFabricator, nameTechnic, typeTechnic, price);

                    command = new MySqlCommand(sql, _connection);
                    object result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    sql = String.Format("INSERT INTO `fabricators`(`id`,`name`) VALUES (NULL,'{0}')", nameFabricator);

                    command = new MySqlCommand(sql, _connection);
                    command.ExecuteNonQuery();

                    return false;
                }
            }

            /// <summary>
            /// Представляет все товары в виде списка;
            /// </summary>
            /// <returns></returns>
            public List<string> OutputProduct()
            {
                string sql = "SELECT t.name, t.type, f.name, t.price FROM `technic` t " +
                    "LEFT OUTER JOIN `fabricators` f ON f.id = t.fabricator_id";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                MySqlDataReader reader = command.ExecuteReader();

                List<string> list = new List<string>();

                while (reader.Read())
                {
                    list.Add(String.Format("Название: {0}; Тип: {1}; Название производителя: {2}; Цена: {3}",
                        reader[0], reader[1], reader[2], reader[3]));
                }
                reader.Close();

                return list;
            }

            /// <summary>
            /// Создаёт новый товар;
            /// </summary>
            /// <param name="name"></param>
            /// <param name="type"></param>
            /// <param name="price"></param>
            /// <param name="nameFabricator"></param>
            /// <returns></returns>
            public bool CreateNewTechnic(string name, string type, string price, string nameFabricator)
            {
                if (CheckFullTechnic(name, type, nameFabricator, price))
                {
                    return false;
                }

                else
                {
                    string sql = String.Format("INSERT INTO `technic`(`id`,`fabricator_id`,`name`,`type`,`price`) VALUES " +
                        "(NULL, (SELECT id FROM fabricators WHERE name = '{0}'), '{1}','{2}',{3})",
                        nameFabricator, name, type, price);

                    MySqlCommand command = new MySqlCommand(sql, _connection);
                    command.ExecuteNonQuery();

                    return true;
                }
            }

            /// <summary>
            /// Представляет все товары в виде списка;
            /// </summary>
            /// <returns></returns>
            public List<string> OutputAllTechnic()
            {
                string sql = "SELECT t.name, t.type, f.name FROM `technic` t " +
                    "LEFT OUTER JOIN `fabricators` f ON f.id = t.fabricator_id";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                MySqlDataReader reader = command.ExecuteReader();

                List<string> list = new List<string>();

                while (reader.Read())
                {
                    list.Add("Название: " + reader[0] + "; Тип: " + reader[1] + "; " +
                        "Кем произведён: " + reader[2]);
                }
                reader.Close();

                return list;
            }

            /// <summary>
            /// Выводит все скидки в указанный DataGrid;
            /// </summary>
            /// <param name="dataGrid"></param>
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

            /// <summary>
            /// Удаляет скидку у указанного товара;
            /// </summary>
            /// <param name="product"></param>
            public void DeleteDiscount(string product = "delete all")
            {
                string sql = string.Empty;

                if (product != "delete all")
                    sql = String.Format("DELETE FROM `discount` WHERE product = '{0}'", product);

                else
                    sql = "DELETE FROM `discount`";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();
            }

            /// <summary>
            /// Проверка на существование в базе данных скидки у указанного продукта;
            /// </summary>
            /// <param name="product"></param>
            /// <returns></returns>
            private bool CheckDiscount(string product)
            {
                string sql = String.Format("SELECT COUNT(*) FROM `discount` WHERE product = '{0}'", product);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                object count = command.ExecuteScalar();

                if (Convert.ToInt32(count) == 0)
                    return false;
                else
                    return true;
            }

            /// <summary>
            /// Добавление новой скидки у указанного продукта;
            /// </summary>
            /// <param name="product"></param>
            /// <param name="discount"></param>
            /// <returns></returns>
            public bool AddDiscount(string product, string discount)
            {
                if (CheckDiscount(product))
                {
                    return false;
                }

                else
                {
                    string sql = String.Format("INSERT INTO `discount`(`product`,`discount`) VALUES ('{0}',{1})",
                        product, discount);

                    MySqlCommand command = new MySqlCommand(sql, _connection);
                    command.ExecuteNonQuery();

                    return true;
                }
            }

            /// <summary>
            /// Изменяет скидку у указанного продукта;
            /// </summary>
            /// <param name="product"></param>
            /// <param name="discount"></param>
            public void UpdateDiscount(string product, string discount)
            {
                string sql = String.Format("UPDATE `discount` SET discount = {0} WHERE product = '{1}'",
                    discount, product);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();
            }

            /// <summary>
            /// Представляет все скидки в виде списка;
            /// </summary>
            /// <returns></returns>
            public List<string> OutputAllDiscount()
            {
                string sql = "SELECT * FROM `discount`";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                MySqlDataReader reader = command.ExecuteReader();

                List<string> list = new List<string>();

                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
                reader.Close();

                return list;
            }

            /// <summary>
            /// Выводит всех сотрудников в указанный DataGrid;
            /// </summary>
            /// <param name="dataGrid"></param>
            public void OutputTableStaff(DataGrid dataGrid)
            {
                dataGrid.Items.Clear();

                string sql = "SELECT second_name,first_name,middle_name,position FROM `staff` ORDER BY " +
                    "second_name,first_name,middle_name";

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

                foreach (string[] s in data)
                {
                    dataGrid.Items.Add(new ItemWorker()
                    {
                        nameWorker = s[0],
                        positionWorker = s[1]
                    });
                }

                reader.Close();
            }

            /// <summary>
            /// Проверка на существование в базе данных сотрудника с указанными данными;
            /// </summary>
            /// <param name="secondName"></param>
            /// <param name="firstName"></param>
            /// <param name="middleName"></param>
            /// <param name="position"></param>
            /// <returns></returns>
            public bool CheckFullStaff(string secondName, string firstName, string middleName, string position)
            {
                object result = new object();

                string sql = String.Format("SELECT id FROM staff WHERE second_name = '{0}' AND " +
                    "first_name = '{1}' AND middle_name = '{2}' AND position = '{3}'",
                    secondName, firstName, middleName, position);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                result = command.ExecuteScalar();

                if (result == null)
                    return false;
                else
                    return true;
            }

            /// <summary>
            /// Создание нового сотрудника с указанными данными;
            /// </summary>
            /// <param name="secondName"></param>
            /// <param name="firstName"></param>
            /// <param name="middleName"></param>
            /// <param name="position"></param>
            public void CreateNewWorker(string secondName, string firstName, string middleName, string position)
            {
                string sql = String.Format("INSERT INTO `staff`(`id`,`second_name`,`first_name`,`middle_name`,`position`) " +
                    "VALUES (NULL, '{0}', '{1}', '{2}', '{3}')", secondName, firstName, middleName, position);

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();
            }

            /// <summary>
            /// Представляет всех сотрудников в виде списка;
            /// </summary>
            /// <returns></returns>
            public List<string> GetStaff()
            {
                string sql = "SELECT second_name,first_name,middle_name,position " +
                    "FROM `staff`";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                MySqlDataReader reader = command.ExecuteReader();

                List<string> list = new List<string>();

                while (reader.Read())
                {
                    list.Add(reader[0] + " " + reader[1] + " " + reader[2]
                        + " " + reader[3]);
                }
                reader.Close();

                return list;
            }
        }
    }
}
