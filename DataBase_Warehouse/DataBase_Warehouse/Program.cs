using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace DataBase_Warehouse
{
    class DataBaseClass
    {
        private MySqlConnection _connection;

        public DataBaseClass()
        {
            _connection = new MySqlConnection("server=127.0.0.1;user=root;database=product_warehouse");
            _connection.Open();
        }

        public void OutputFurnitureTable(DataGridView DGV)
        {
            DGV.Rows.Clear();

            string sql = "SELECT * FROM furniture";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            string allTable = "";

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
            }

            reader.Close();

            foreach (string[] s in data)
                DGV.Rows.Add(s);
        }


        /// <summary>
        /// Удаление заказа мебели;
        /// </summary>
        /// <param name="TB"></param>
        public void DeleteOrderFurniture(TextBox TB)
        {
            int neededOrder = Convert.ToInt32(TB.Text);

            string sqlFirst = "SELECT buyer_id FROM furniture WHERE item_code = " + neededOrder.ToString();
            MySqlCommand commandFirst = new MySqlCommand(sqlFirst, _connection);
            MySqlDataReader readerFirst = commandFirst.ExecuteReader();
            int buyer_id = new int();
            while (readerFirst.Read())
                buyer_id = Convert.ToInt32(readerFirst[0]);
            readerFirst.Close();

            string sqlSecond = "SELECT item_code FROM furniture WHERE buyer_id = " + buyer_id.ToString();
            MySqlCommand commandSecond = new MySqlCommand(sqlSecond, _connection);
            MySqlDataReader readerSecond = commandSecond.ExecuteReader();

            int count = 0;
            while (readerSecond.Read())
            {
                count++;
            }
            readerSecond.Close();

            // Если покупатель приобрёл несколько товаров, тогда просто удаляем один заказ;
            if (count > 1)
            {
                string sqlThird = "DELETE FROM furniture WHERE item_code = " + neededOrder;
                MySqlCommand commandThird = new MySqlCommand(sqlThird, _connection);
                commandThird.ExecuteNonQuery();
            }

            // Иначе удаялется не только заказ, но и клиент; 
            else
            {
                string sqlThird = "DELETE FROM furniture WHERE item_code = " + neededOrder.ToString();
                MySqlCommand commandThird = new MySqlCommand(sqlThird, _connection);
                commandThird.ExecuteNonQuery();

                string sqlFourth = "DELETE FROM buyers WHERE id = " + buyer_id.ToString();
                MySqlCommand commandFourth = new MySqlCommand(sqlFourth, _connection);
                commandFourth.ExecuteNonQuery();
            }
        }

        private bool CheckFullProduct(TextBox type, TextBox name, TextBox material, object result)
        {
            string sql = "SELECT id FROM product WHERE type = '" + type.Text + "' AND name = '" +
                name.Text + "' AND material = '" + material.Text + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else 
                return true;
        }

        private bool CheckFullColor(TextBox name, object result)
        {
            string sql = "SELECT id FROM colors WHERE name = '" + name.Text + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private bool CheckFullAdress(TextBox country, TextBox city, TextBox street, object result)
        {
            string sql = "SELECT id FROM address WHERE country = '" + country.Text + "' AND city = '" 
                + city.Text + "' AND street = '" + street.Text + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private bool CheckFullBuyer(TextBox firstName, TextBox secondName, TextBox middleName, TextBox country, 
            TextBox city, TextBox street, TextBox phoneNumber, object result)
        {
            object resultAdress = new object();
            string sql = string.Empty;

            if (CheckFullAdress(country, city, street, resultAdress))
            {
                sql = "SELECT id FROM buyers WHERE first_name = '" + firstName.Text + "' AND second_name = '"
                + secondName.Text + "' AND middle_name = '" + middleName.Text + 
                "' AND address_id = '" + resultAdress.ToString() + "' AND phone_number = '" + phoneNumber.Text + "'";
            }
            else
            {
                string sqlAdd = "INSERT INTO `address`(`id`,`country`,`city`,`street`) VALUES (NULL,'" + country.Text + 
                    "','" + city.Text + "','" + street.Text + "')";
                MySqlCommand commandAdd = new MySqlCommand(sqlAdd, _connection);
                commandAdd.ExecuteNonQuery();

                sql = "SELECT id FROM buyers WHERE first_name = '" + firstName.Text + "' AND second_name = '"
                + secondName.Text + "' AND middle_name = '" + middleName.Text +
                "' AND address_id = (SELECT id FROM address WHERE country = '" + country.Text + "' AND city = '"
                + city.Text + "' AND street = '" + street.Text + "') AND phone_number = '" + phoneNumber.Text +"'";
            }

            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private bool CheckFullFabricator(TextBox name, TextBox country, TextBox city, TextBox street, TextBox phoneNumber, object result)
        {
            object resultAdress = new object();
            string sql = string.Empty;

            if (CheckFullAdress(country, city, street, resultAdress))
            {
                sql = "SELECT id FROM fabricators WHERE name = '" + name.Text + 
                "' AND address_id = '" + resultAdress.ToString() + "' AND phone_number = '" + phoneNumber.Text + "'";
            }
            else
            {
                string sqlAdd = "INSERT INTO `address`(`id`,`country`,`city`,`street`) VALUES (NULL,'" + country.Text +
                    "','" + city.Text + "','" + street.Text + "')";
                MySqlCommand commandAdd = new MySqlCommand(sqlAdd, _connection);
                commandAdd.ExecuteNonQuery();

                sql = "SELECT id FROM fabricators WHERE name = '" + name.Text +
                "' AND address_id = (SELECT id FROM address WHERE country = '" + country.Text + "' AND city = '"
                + city.Text + "' AND street = '" + street.Text + "') AND phone_number = '" + phoneNumber.Text + "'";
            }

            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private void CreateNewBuyer(TextBox firstName, TextBox secondName, TextBox middleName,
            TextBox country, TextBox city, TextBox street, TextBox phoneNumber)
        {
            string sqlAdd = "INSERT INTO `buyers`(`id`,`first_name`,`second_name`,`middle_name`,`address_id`,`phone_number`) " +
                "VALUES (NULL,'" + firstName.Text + "','" + secondName.Text + "','" + middleName.Text + 
                "',(SELECT id FROM address WHERE country = '" + country.Text + "' AND city = '" + city.Text + 
                "' AND street = '" + street.Text + "'),'" + phoneNumber.Text + "')";

            MySqlCommand command = new MySqlCommand(sqlAdd, _connection);
            command.ExecuteNonQuery();
        }

        private void CreateNewFabricator(TextBox name, TextBox country, TextBox city, 
            TextBox street, TextBox phoneNumber)
        {
            string sqlAdd = "INSERT INTO `fabricators`(`id`,`name`,`address_id`,`phone_number`) " +
                "VALUES (NULL,'" + name.Text + "',(SELECT id FROM address WHERE country = '"
                + country.Text + "' AND city = '" + city.Text + "' AND street = '" + street.Text + "'),'"
                + phoneNumber.Text + "')";

            MySqlCommand command = new MySqlCommand(sqlAdd, _connection);
            command.ExecuteNonQuery();
        }

        private void CreateNewColor(TextBox name)
        {
            string sqlAdd = "INSERT INTO `colors`(`id`,`name`) VALUES (NULL,'" + name.Text + "')";

            MySqlCommand command = new MySqlCommand(sqlAdd, _connection);
            command.ExecuteNonQuery();
        }
        
        private void CreateNewProduct(TextBox type, TextBox name, TextBox material)
        {
            string sqlAdd = "INSERT INTO `product`(`id`,`type`,`name`,`material`) VALUES (NULL,'" + type.Text + "','" + name.Text + "','" + material.Text + "')";

            MySqlCommand command = new MySqlCommand(sqlAdd, _connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Формирует новый заказ;
        /// </summary>
        public void NewOrderFurniture(TextBox type, TextBox nameProduct, TextBox material, TextBox count, TextBox nameColor,
            TextBox nameFabricator, TextBox countryFabricator, TextBox cityFabricator, TextBox streetFabricator, TextBox phoneNumberFabricator,
            TextBox firstNameBuyer, TextBox secondNameBuyer,TextBox middleNameBuyer, TextBox countryBuyer, TextBox cityBuyer,
            TextBox streetBuyer, TextBox phoneNumberBuyer, TextBox dateDelivery, TextBox priceProduct)
        {
            object firstResult = new object();
            object secondResult = new object();
            object thirdResult = new object();
            object fourthResult = new object();

            bool fullBuyer = CheckFullBuyer(firstNameBuyer, secondNameBuyer, middleNameBuyer, countryBuyer,
                cityBuyer, streetBuyer, phoneNumberBuyer, firstResult);

            bool fullFabricator = CheckFullFabricator(nameFabricator, countryFabricator,
                cityFabricator, streetFabricator, phoneNumberFabricator, secondResult);

            bool fullColor = CheckFullColor(nameColor, thirdResult);

            bool fullProduct = CheckFullProduct(type, nameProduct, material, fourthResult);

            if (!fullBuyer)
            {
                CreateNewBuyer(firstNameBuyer, secondNameBuyer, middleNameBuyer,
                    countryBuyer, cityBuyer, streetBuyer, phoneNumberBuyer);

                string sql = "SELECT id FROM buyers WHERE first_name = '" + firstNameBuyer.Text + "' AND second_name = '"
                + secondNameBuyer.Text + "' AND middle_name = '" + middleNameBuyer.Text +
                "' AND address_id = (SELECT id FROM address WHERE country = '" + countryBuyer.Text + "' AND city = '"
                + cityBuyer.Text + "' AND street = '" + streetBuyer.Text + "') AND phone_number = '" + phoneNumberBuyer.Text + "'";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                firstResult = command.ExecuteScalar(); 
            }

            if (!fullFabricator)
            {
                CreateNewFabricator(nameFabricator, countryFabricator, cityFabricator, 
                    streetFabricator, phoneNumberFabricator);

                string sql = "SELECT id FROM fabricators WHERE name = '" + nameFabricator.Text +
                "' AND address_id = (SELECT id FROM address WHERE country = '" + countryFabricator.Text + "' AND city = '"
                + cityFabricator.Text + "' AND street = '" + streetFabricator.Text + "') AND phone_number = '" + phoneNumberFabricator.Text + "'";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                secondResult = command.ExecuteScalar();
            }

            if (!fullColor)
            {
                CreateNewColor(nameColor);

                string sql = "SELECT id FROM colors WHERE name = '" + nameColor.Text + "'";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                thirdResult = command.ExecuteScalar();
            }

            if (!fullProduct)
            {
                CreateNewProduct(type, nameProduct, material);

                string sql = "SELECT id FROM product WHERE type = '" + type.Text + "' AND name = '" +
                nameProduct.Text + "' AND material = '" + material.Text + "'";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                fourthResult = command.ExecuteScalar();
            }

            string sqlAdd = "INSERT INTO `furniture`(`item_code`,`product_id`,`count`,`color_id`,`fabricator_id`,`buyer_id`,`price_product`)" +
                " VALUES (NULL,'" + fourthResult.ToString() + "'," + count.Text + ",'" + thirdResult.ToString() + "','" + secondResult.ToString() +
                "','" + firstResult.ToString() + "'," + priceProduct.Text + ")";

            MySqlCommand commandAdd = new MySqlCommand(sqlAdd, _connection);
            commandAdd.ExecuteNonQuery();
        }

        ~DataBaseClass()
        {
            _connection.Close();
        }

    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
