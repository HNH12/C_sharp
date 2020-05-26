using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using MySqlX.XDevAPI.Relational;
using MySqlX.XDevAPI.Common;
using System.Data.Common;

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

        public void OutputTable(DataGridView DGV, string tableName, int choose = 0)
        {
            DGV.Rows.Clear();

            string sql = String.Empty;
            switch (choose)
            {
                case 0: sql = "SELECT * FROM " + tableName; break;
                case 1: sql = "SELECT * FROM " + tableName + " WHERE status = 'на складе'"; break;
                case 2: sql = "SELECT * FROM " + tableName + " WHERE status = 'закрыт'"; break;
            }
            
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }

            reader.Close();

            foreach (string[] s in data)
                DGV.Rows.Add(s);
        }

        /// <summary>
        /// Удаление заказа мебели;
        /// </summary>
        /// <param name="TB"></param>
        public void DeleteOrder(TextBox TB, string tableName)
        {
            int neededOrder = Convert.ToInt32(TB.Text);
    
            string sqlThird = "DELETE FROM " + tableName + " WHERE item_code = " + neededOrder;
            MySqlCommand commandThird = new MySqlCommand(sqlThird, _connection);
            commandThird.ExecuteNonQuery();
        }

        private bool CheckFullProduct(TextBox type, TextBox name, TextBox material, ref object result)
        {
            string sql = "SELECT id FROM product_furniture WHERE type = '" + type.Text + "' AND name = '" +
                name.Text + "' AND material = '" + material.Text + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else 
                return true;
        }

        private bool CheckFullProduct(TextBox type, TextBox name, string tableName, ref object result)
        {
            string sql = "SELECT id FROM " + tableName + " WHERE type = '" + type.Text + "' AND name = '" +
                name.Text + "'";

            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private bool CheckFullColor(TextBox name, ref object result)
        {
            string sql = "SELECT id FROM colors WHERE name = '" + name.Text + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            result = command.ExecuteScalar();

            if (result == null)
                return false;
            else
                return true;
        }

        private bool CheckFullAdress(TextBox country, TextBox city, TextBox street, ref object result)
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
            TextBox city, TextBox street, TextBox phoneNumber, ref object result)
        {
            object resultAdress = new object();
            string sql = string.Empty;

            if (CheckFullAdress(country, city, street, ref resultAdress))
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


        private bool CheckFullFabricator(TextBox name, TextBox country, TextBox city, TextBox street, TextBox phoneNumber, ref object result)
        {
            object resultAdress = new object();
            string sql = string.Empty;

            if (CheckFullAdress(country, city, street, ref resultAdress))
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
            string sqlAdd = "INSERT INTO `product_furniture`(`id`,`type`,`name`,`material`) VALUES (NULL,'" + type.Text + "','" + name.Text + "','" + material.Text + "')";

            MySqlCommand command = new MySqlCommand(sqlAdd, _connection);
            command.ExecuteNonQuery();
        }

        private void CreateNewProduct(TextBox type, TextBox name, string tableName)
        {
            string sqlAdd = "INSERT INTO `" + tableName + "`(`id`,`type`,`name`) VALUES (NULL,'" + type.Text + "','" + name.Text + "')";

            MySqlCommand command = new MySqlCommand(sqlAdd, _connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Формирует новый заказ;
        /// </summary>
        public void NewOrderFurniture(TextBox type, TextBox nameProduct, TextBox material, TextBox count, TextBox nameColor,
            TextBox nameFabricator, TextBox countryFabricator, TextBox cityFabricator, TextBox streetFabricator, TextBox phoneNumberFabricator,
            TextBox firstNameBuyer, TextBox secondNameBuyer,TextBox middleNameBuyer, TextBox countryBuyer, TextBox cityBuyer,
            TextBox streetBuyer, TextBox phoneNumberBuyer, TextBox priceProduct)
        {
            object firstResult = new object();
            object secondResult = new object();
            object thirdResult = new object();
            object fourthResult = new object();

            bool fullBuyer = CheckFullBuyer(firstNameBuyer, secondNameBuyer, middleNameBuyer, countryBuyer,
                cityBuyer, streetBuyer, phoneNumberBuyer, ref firstResult);

            bool fullFabricator = CheckFullFabricator(nameFabricator, countryFabricator,
                cityFabricator, streetFabricator, phoneNumberFabricator, ref secondResult);

            bool fullColor = CheckFullColor(nameColor, ref thirdResult);

            bool fullProduct = CheckFullProduct(type, nameProduct, material, ref fourthResult);

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

                string sql = "SELECT id FROM product_furniture WHERE type = '" + type.Text + "' AND name = '" +
                nameProduct.Text + "' AND material = '" + material.Text + "'";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                fourthResult = command.ExecuteScalar();
            }

            string sqlAdd = "INSERT INTO `furniture`(`item_code`,`product_id`,`count`,`color_id`,`fabricator_id`,`buyer_id`,`price_product`,`status`)" +
                " VALUES (NULL,'" + fourthResult.ToString() + "'," + count.Text + ",'" + thirdResult.ToString() + "','" + secondResult.ToString() +
                "','" + firstResult.ToString() + "'," + priceProduct.Text + ",'на складе')";

            MySqlCommand commandAdd = new MySqlCommand(sqlAdd, _connection);
            commandAdd.ExecuteNonQuery();
        }

        public void NewOrderElectronics(TextBox type, TextBox nameProduct, TextBox count, TextBox nameColor,
            TextBox nameFabricator, TextBox countryFabricator, TextBox cityFabricator, TextBox streetFabricator, TextBox phoneNumberFabricator,
            TextBox firstNameBuyer, TextBox secondNameBuyer, TextBox middleNameBuyer, TextBox countryBuyer, TextBox cityBuyer,
            TextBox streetBuyer, TextBox phoneNumberBuyer, TextBox priceProduct)
        {
            object firstResult = new object();
            object secondResult = new object();
            object thirdResult = new object();
            object fourthResult = new object();

            bool fullBuyer = CheckFullBuyer(firstNameBuyer, secondNameBuyer, middleNameBuyer, countryBuyer,
                cityBuyer, streetBuyer, phoneNumberBuyer, ref firstResult);

            bool fullFabricator = CheckFullFabricator(nameFabricator, countryFabricator,
                cityFabricator, streetFabricator, phoneNumberFabricator, ref secondResult);

            bool fullColor = CheckFullColor(nameColor, ref thirdResult);

            bool fullProduct = CheckFullProduct(type, nameProduct, "product_electronic", ref fourthResult);

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
                CreateNewProduct(type, nameProduct, "product_electronic");

                string sql = "SELECT id FROM product_electronic WHERE type = '" + type.Text + "' AND name = '" +
                nameProduct.Text + "'";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                fourthResult = command.ExecuteScalar();
            }

            string sqlAdd = "INSERT INTO `electronics`(`item_code`,`product_id`,`count`,`color_id`,`fabricator_id`,`buyer_id`,`price_product`,`status`)" +
                " VALUES (NULL,'" + fourthResult.ToString() + "'," + count.Text + ",'" + thirdResult.ToString() + "','" + secondResult.ToString() +
                "','" + firstResult.ToString() + "'," + priceProduct.Text + ",'на складе')";

            MySqlCommand commandAdd = new MySqlCommand(sqlAdd, _connection);
            commandAdd.ExecuteNonQuery();
        }

        public void NewOrderCars(TextBox type, TextBox nameProduct, TextBox count, TextBox nameColor,
            TextBox nameFabricator, TextBox countryFabricator, TextBox cityFabricator, TextBox streetFabricator, TextBox phoneNumberFabricator,
            TextBox firstNameBuyer, TextBox secondNameBuyer, TextBox middleNameBuyer, TextBox countryBuyer, TextBox cityBuyer,
            TextBox streetBuyer, TextBox phoneNumberBuyer, TextBox priceProduct)
        {
            object firstResult = new object();
            object secondResult = new object();
            object thirdResult = new object();
            object fourthResult = new object();

            bool fullBuyer = CheckFullBuyer(firstNameBuyer, secondNameBuyer, middleNameBuyer, countryBuyer,
                cityBuyer, streetBuyer, phoneNumberBuyer, ref firstResult);

            bool fullFabricator = CheckFullFabricator(nameFabricator, countryFabricator,
                cityFabricator, streetFabricator, phoneNumberFabricator, ref secondResult);

            bool fullColor = CheckFullColor(nameColor, ref thirdResult);

            bool fullProduct = CheckFullProduct(type, nameProduct, "product_car", ref fourthResult);

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
                CreateNewProduct(type, nameProduct, "product_car");

                string sql = "SELECT id FROM product_car WHERE type = '" + type.Text + "' AND name = '" +
                nameProduct.Text + "'";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                fourthResult = command.ExecuteScalar();
            }

            string sqlAdd = "INSERT INTO `electronics`(`item_code`,`product_id`,`count`,`color_id`,`fabricator_id`,`buyer_id`,`price_product`,`status`)" +
                " VALUES (NULL,'" + fourthResult.ToString() + "'," + count.Text + ",'" + thirdResult.ToString() + "','" + secondResult.ToString() +
                "','" + firstResult.ToString() + "'," + priceProduct.Text + ",'на складе')";

            MySqlCommand commandAdd = new MySqlCommand(sqlAdd, _connection);
            commandAdd.ExecuteNonQuery();
        }

        public void UpdateStatus(int id, string tableName)
        {
            string sql = "SELECT status FROM `" + tableName + "` WHERE item_code = " + id;
            MySqlCommand command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();

            string newStatus = string.Empty;

            if (result.ToString() == "закрыт")
                newStatus = "на складе";
            else
                newStatus = "закрыт";

            sql = "UPDATE `" + tableName + "` SET `status` = '"+newStatus+"' WHERE `item_code` = " + id;
            command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        public void OrderInformationElectronic (TextBox type, TextBox nameProduct, TextBox count, TextBox nameColor,
            TextBox nameFabricator, TextBox countryFabricator, TextBox cityFabricator, TextBox streetFabricator, TextBox phoneNumberFabricator,
            TextBox firstNameBuyer, TextBox secondNameBuyer, TextBox middleNameBuyer, TextBox countryBuyer, TextBox cityBuyer,
            TextBox streetBuyer, TextBox phoneNumberBuyer, TextBox priceProduct, TextBox status, int id)
        {
            string sql = "SELECT pe.type, pe.name, e.count, c.name, b.first_name, b.second_name, b.middle_name," +
                "b.phone_number, a1.country, a1.city, a1.street, f.name, f.phone_number, a2.country, a2.city, a2.street, e.price_product, e.status "
                       + "FROM `electronics` e \n"
                       + "RIGHT OUTER JOIN `product_electronic` pe ON pe.id = e.product_id\n"
                       + "RIGHT OUTER JOIN `colors` c ON c.id = e.color_id\n"
                       + "RIGHT OUTER JOIN `buyers` b ON b.id = e.buyer_id\n"
                       + "RIGHT OUTER JOIN `address` a1 ON a1.id = b.address_id\n"
                       + "RIGHT OUTER JOIN `fabricators` f ON f.id = e.fabricator_id\n"
                       + "RIGHT OUTER JOIN `address` a2 ON a2.id = f.address_id\n"
                       + "WHERE e.item_code = " + id.ToString();

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                type.Text = reader[0].ToString();
                nameProduct.Text = reader[1].ToString();
                count.Text = reader[2].ToString();
                nameColor.Text = reader[3].ToString();
                firstNameBuyer.Text = reader[4].ToString();
                secondNameBuyer.Text = reader[5].ToString();
                middleNameBuyer.Text = reader[6].ToString();
                phoneNumberBuyer.Text = reader[7].ToString();
                countryBuyer.Text = reader[8].ToString();
                cityBuyer.Text = reader[9].ToString();
                streetBuyer.Text = reader[10].ToString();
                nameFabricator.Text = reader[11].ToString();
                phoneNumberFabricator.Text = reader[12].ToString();
                countryFabricator.Text = reader[13].ToString();
                cityFabricator.Text = reader[14].ToString();
                streetFabricator.Text = reader[15].ToString();
                priceProduct.Text = reader[16].ToString();
                status.Text = reader[17].ToString();
            }
        }

        public void OrderInformationCar(TextBox type, TextBox nameProduct, TextBox count, TextBox nameColor,
            TextBox nameFabricator, TextBox countryFabricator, TextBox cityFabricator, TextBox streetFabricator, TextBox phoneNumberFabricator,
            TextBox firstNameBuyer, TextBox secondNameBuyer, TextBox middleNameBuyer, TextBox countryBuyer, TextBox cityBuyer,
            TextBox streetBuyer, TextBox phoneNumberBuyer, TextBox priceProduct, TextBox status, int id)
        {
            string sql = "SELECT pe.type, pe.name, e.count, c.name, b.first_name, b.second_name, b.middle_name," +
                "b.phone_number, a1.country, a1.city, a1.street, f.name, f.phone_number, a2.country, a2.city, a2.street, e.price_product, e.status "
                       + "FROM `cars` e \n"
                       + "RIGHT OUTER JOIN `product_car` pe ON pe.id = e.product_id\n"
                       + "RIGHT OUTER JOIN `colors` c ON c.id = e.color_id\n"
                       + "RIGHT OUTER JOIN `buyers` b ON b.id = e.buyer_id\n"
                       + "RIGHT OUTER JOIN `address` a1 ON a1.id = b.address_id\n"
                       + "RIGHT OUTER JOIN `fabricators` f ON f.id = e.fabricator_id\n"
                       + "RIGHT OUTER JOIN `address` a2 ON a2.id = f.address_id\n"
                       + "WHERE e.item_code = " + id.ToString();

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                type.Text = reader[0].ToString();
                nameProduct.Text = reader[1].ToString();
                count.Text = reader[2].ToString();
                nameColor.Text = reader[3].ToString();
                firstNameBuyer.Text = reader[4].ToString();
                secondNameBuyer.Text = reader[5].ToString();
                middleNameBuyer.Text = reader[6].ToString();
                phoneNumberBuyer.Text = reader[7].ToString();
                countryBuyer.Text = reader[8].ToString();
                cityBuyer.Text = reader[9].ToString();
                streetBuyer.Text = reader[10].ToString();
                nameFabricator.Text = reader[11].ToString();
                phoneNumberFabricator.Text = reader[12].ToString();
                countryFabricator.Text = reader[13].ToString();
                cityFabricator.Text = reader[14].ToString();
                streetFabricator.Text = reader[15].ToString();
                priceProduct.Text = reader[16].ToString();
                status.Text = reader[17].ToString();
            }
        }

        public void OrderInformationFurniture(TextBox type, TextBox nameProduct, TextBox material, TextBox count, TextBox nameColor,
            TextBox nameFabricator, TextBox countryFabricator, TextBox cityFabricator, TextBox streetFabricator, TextBox phoneNumberFabricator,
            TextBox firstNameBuyer, TextBox secondNameBuyer, TextBox middleNameBuyer, TextBox countryBuyer, TextBox cityBuyer,
            TextBox streetBuyer, TextBox phoneNumberBuyer, TextBox priceProduct, TextBox status, int id)
        {
            string sql = "SELECT pe.type, pe.name, pe.material, e.count, c.name, b.first_name, b.second_name, b.middle_name," +
                "b.phone_number, a1.country, a1.city, a1.street, f.name, f.phone_number, a2.country, a2.city, a2.street, e.price_product, e.status "
                       + "FROM `furniture` e \n"
                       + "RIGHT OUTER JOIN `product_furniture` pe ON pe.id = e.product_id\n"
                       + "RIGHT OUTER JOIN `colors` c ON c.id = e.color_id\n"
                       + "RIGHT OUTER JOIN `buyers` b ON b.id = e.buyer_id\n"
                       + "RIGHT OUTER JOIN `address` a1 ON a1.id = b.address_id\n"
                       + "RIGHT OUTER JOIN `fabricators` f ON f.id = e.fabricator_id\n"
                       + "RIGHT OUTER JOIN `address` a2 ON a2.id = f.address_id\n"
                       + "WHERE e.item_code = " + id.ToString();

            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                type.Text = reader[0].ToString();
                nameProduct.Text = reader[1].ToString();
                material.Text = reader[2].ToString();
                count.Text = reader[3].ToString();
                nameColor.Text = reader[4].ToString();
                firstNameBuyer.Text = reader[5].ToString();
                secondNameBuyer.Text = reader[6].ToString();
                middleNameBuyer.Text = reader[7].ToString();
                phoneNumberBuyer.Text = reader[8].ToString();
                countryBuyer.Text = reader[9].ToString();
                cityBuyer.Text = reader[10].ToString();
                streetBuyer.Text = reader[11].ToString();
                nameFabricator.Text = reader[12].ToString();
                phoneNumberFabricator.Text = reader[13].ToString();
                countryFabricator.Text = reader[14].ToString();
                cityFabricator.Text = reader[15].ToString();
                streetFabricator.Text = reader[16].ToString();
                priceProduct.Text = reader[17].ToString();
                status.Text = reader[18].ToString();
            }
        }

        public void OutputAllOrdersCount(TextBox count, string nameTable)
        {
            string sql = "SELECT COUNT(*) FROM `" + nameTable+"`";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();
            count.Text = result.ToString();
        }

        public void OutputCurrentOrdersCount(TextBox count, string nameTable)
        {
            string sql = "SELECT COUNT(*) FROM `"+nameTable+"` WHERE status = 'на складе'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();
            count.Text = result.ToString();
        }

        public void OutputEndedOrdersCount(TextBox count, string nameTable)
        {
            string sql = "SELECT COUNT(*) FROM `" + nameTable + "` WHERE status = 'закрыт'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();
            count.Text = result.ToString();
        }

        public void OutputAllObjectsCount(TextBox count, string nameTable)
        {
            string sql = "SELECT SUM(count) FROM `"+nameTable+"`";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();
            count.Text = result.ToString();
        }

        public void OutputCurrentObjectsCount(TextBox count, string nameTable)
        {
            string sql = "SELECT SUM(count) FROM `" + nameTable + "` WHERE status = 'на складе'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();
            count.Text = result.ToString();
        }

        public void OutputEndedObjectsCount(TextBox count, string nameTable)
        {
            string sql = "SELECT SUM(count) FROM `" + nameTable + "` WHERE status = 'закрыт'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();
            count.Text = result.ToString();
        }

        public void MostExpensiveItem(TextBox item, string nameTable)
        {
            string sql = string.Empty;

            switch (nameTable)
            {
                case "furniture":
                    sql = "SELECT type,name FROM `product_furniture` WHERE id = (" +
                        "SELECT item_code FROM `furniture` WHERE price_product = (" +
                        "SELECT MAX(price_product) FROM `furniture`)" +
                        " LIMIT 1)";
                    break;

                case "electronics":
                    sql = "SELECT type,name FROM `product_electronic` WHERE id = (" +
                        "SELECT item_code FROM `electronics` WHERE price_product = (" +
                        "SELECT MAX(price_product) FROM `electronics`)" +
                        " LIMIT 1)";
                    break;

                case "cars":
                    sql = "SELECT type,name FROM `product_car` WHERE id = (" +
                        "SELECT item_code FROM `cars` WHERE price_product = (" +
                        "SELECT MAX(price_product) FROM `cars`)" +
                        " LIMIT 1)";
                    break;
            }
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            string res = string.Empty;
            while (reader.Read())
            {
                res = "Тип: " + reader[0].ToString() + "; Название: " + reader[1].ToString();
            }
            reader.Close();
            item.Text = res;

            sql = "SELECT MAX(price_product) FROM `" + nameTable + "`";
            command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();
            item.AppendText("; Цена: " + result.ToString());
        }

        public void CheapestItem(TextBox item, string nameTable)
        {
            string sql = string.Empty;

            switch (nameTable)
            {
                case "furniture":
                    sql = "SELECT type,name FROM `product_furniture` WHERE id = (" +
                        "SELECT item_code FROM `furniture` WHERE price_product = (" +
                        "SELECT MIN(price_product) FROM `furniture`)" +
                        " LIMIT 1)";
                    break;

                case "electronics":
                    sql = "SELECT type,name FROM `product_electronic` WHERE id = (" +
                        "SELECT item_code FROM `electronics` WHERE price_product = (" +
                        "SELECT MIN(price_product) FROM `electronics`)" +
                        " LIMIT 1)";
                    break;

                case "cars":
                    sql = "SELECT type,name FROM `product_car` WHERE id = (" +
                        "SELECT item_code FROM `cars` WHERE price_product = (" +
                        "SELECT MIN(price_product) FROM `cars`)" +
                        " LIMIT 1)";
                    break;
            }
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            string res = string.Empty;
            while (reader.Read())
            {
                res = "Тип: " + reader[0].ToString() + "; Название: " + reader[1].ToString();
            }
            reader.Close();
            item.Text = res;

            sql = "SELECT MIN(price_product) FROM `" + nameTable + "`";
            command = new MySqlCommand(sql, _connection);
            object result = command.ExecuteScalar();
            item.AppendText("; Цена: " + result.ToString());
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
